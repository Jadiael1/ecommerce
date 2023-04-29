using Domain.Entities;

namespace Application.Interfaces;

public interface IDataShapeHelper<T>
{
    IEnumerable<Entity> ShapeData(IEnumerable<T> entities, string fieldsString);
    IEnumerable<T> ShapeDataGeneric(IEnumerable<T> entities, string fieldsString);
    Task<IEnumerable<Entity>> ShapeDataAsync(IEnumerable<T> entities, string fieldsString);
    Entity ShapeData(T entity, string fieldsString);
    void SetPropertyDayOfWeek(T entity, DayOfWeek[] day);
    void SetPropertyDayOfMonth(T entity, int[] day);
    void RemovePropertyValue(T entity, string propName);
}
