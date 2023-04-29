using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using System.Globalization;
using System.Reflection;

namespace Application.Helpers;

public class DataShapeHelper<T> : IDataShapeHelper<T>
{
    public PropertyInfo[] Properties { get; set; }

    public DataShapeHelper()
    {
        Properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    }

    public IEnumerable<Entity> ShapeData(IEnumerable<T> entities, string fieldsString)
    {
        var requiredProperties = GetRequiredProperties(fieldsString);

        return FetchData(entities, requiredProperties);
    }

    public IEnumerable<T> ShapeDataGeneric(IEnumerable<T> entities, string fieldsString)
    {
        var requiredProperties = GetRequiredProperties(fieldsString);

        return FetchDataGeneric(entities, requiredProperties);
    }


    public async Task<IEnumerable<Entity>> ShapeDataAsync(IEnumerable<T> entities, string fieldsString)
    {
        var requiredProperties = GetRequiredProperties(fieldsString);

        return await Task.Run(() => FetchData(entities, requiredProperties));
    }

    public Entity ShapeData(T entity, string fieldsString)
    {
        var requiredProperties = GetRequiredProperties(fieldsString);

        return FetchDataForEntity(entity, requiredProperties);
    }

    private IEnumerable<PropertyInfo> GetRequiredProperties(string fieldsString)
    {
        var requiredProperties = new List<PropertyInfo>();

        if (!string.IsNullOrWhiteSpace(fieldsString))
        {
            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var field in fields)
            {
                var property = Properties.FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property == null)
                    continue;

                //if (property.PropertyType.IsClass && property.PropertyType.FullName != "System.String")
                //  property = property.PropertyType.GetProperty("NOME");

                requiredProperties.Add(property);
            }
        }
        else
        {
            requiredProperties = Properties.ToList();
        }

        return requiredProperties;
    }

    private IEnumerable<Entity> FetchData(IEnumerable<T> entities, IEnumerable<PropertyInfo> requiredProperties)
    {
        var shapedData = new List<Entity>();

        foreach (var entity in entities)
        {
            var shapedObject = FetchDataForEntity(entity, requiredProperties);
            shapedData.Add(shapedObject);
        }

        return shapedData;
    }

    private IEnumerable<T> FetchDataGeneric(IEnumerable<T> entities, IEnumerable<PropertyInfo> requiredProperties)
    {
        var shapedData = new List<T>();

        foreach (var entity in entities)
        {
            var shapedObject = FetchDataForEntityGeneric(entity, requiredProperties);
            shapedData.Add(shapedObject);
        }

        return shapedData;
    }

    private Entity FetchDataForEntity(T entity, IEnumerable<PropertyInfo> requiredProperties)
    {
        var shapedObject = new Entity();

        foreach (var property in requiredProperties)
        {
            var objectPropertyValue = property.GetValue(entity);
            shapedObject.TryAdd(property.Name, objectPropertyValue);
        }

        return shapedObject;
    }

    private T FetchDataForEntityGeneric(object entity, IEnumerable<PropertyInfo> requiredProperties)
    {
        Type t = entity.GetType();
        foreach (var property in requiredProperties)
        {
            var objectPropertyValue = property.GetValue(entity);
            var propInfo = t.GetProperty(property.Name);
            propInfo.SetValue(t, objectPropertyValue, null);
        }

        return (T)entity;
    }

    public void SetPropertyDayOfWeek(T entity, DayOfWeek[] days)
    {
        if (days == null)
            return;

        foreach (var day in days)
        {
            var dayProperty = "SEMANAL_" + new CultureInfo("pt-BR").DateTimeFormat.GetDayName(day).ToUpper().Replace("-FEIRA", "").Replace("Ç", "C").Replace("Á", "A");
            SetPropertyValue(entity, dayProperty, EStatus.Verdadeiro);
        }
    }

    public void SetPropertyDayOfMonth(T entity, int[] days)
    {
        if (days == null)
            return;

        foreach (var day in days)
        {
            string textDay = day.ToString();
            if (textDay.Length == 1)
                textDay = "0" + textDay;

            var dayProperty = "MENSAL_DIA" + textDay;
            SetPropertyValue(entity, dayProperty, EStatus.Verdadeiro);
        }
    }

    public void RemovePropertyValue(T entity, string propName)
    {
        if (propName == "SEMANAL")
        {
            for (int i = 0; i <= 6; ++i)
            {
                var dayProperty = "SEMANAL_" + new CultureInfo("pt-BR").DateTimeFormat.GetDayName((DayOfWeek)i).ToUpper().Replace("-FEIRA", "").Replace("Ç", "C").Replace("Á", "A");
                SetPropertyValue(entity, dayProperty, EStatus.Falso);
            }

        }
        else if (propName == "MENSAL")
        {
            for (int i = 1; i <= 31; ++i)
            {
                string textDay = i.ToString();
                if (textDay.Length == 1)
                    textDay = "0" + textDay;

                var dayProperty = "MENSAL_DIA" + textDay;
                SetPropertyValue(entity, dayProperty, EStatus.Falso);
            }
        }
    }

    private void SetPropertyValue(T entity, string propName, object value)
    {
        entity.GetType().GetProperty(propName).SetValue(entity, value, null);
    }
}

