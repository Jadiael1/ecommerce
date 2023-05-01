namespace Domain.Enums;

public enum EStatusPedido
{
    AGUARDANDOPROCESSAMENTO = 'A',
    EMFILA = 'F',
    JOBATRIBUIDO = 'J',
    PROCESSANDO = 'E',
    AGUARDANDOFILHOS = 'W',
    PROCESSADO = 'P',
    SELECIONADO = 'T',
    CANCELADO = 'C',
}

