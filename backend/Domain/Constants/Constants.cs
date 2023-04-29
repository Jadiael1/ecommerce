namespace Domain.Constants;

public class Constants
{
    public class TipoRepositorio
    {
        public const string ANALISE = "A";
        public const string METRICA = "M";
        public const string INDICADOR = "I";
    }

    public class CadeiaValor
    {
        public const string APOIO = "0AP";
        public const string COMPRAR = "1CP";
        public const string RECEBER = "2RC";
        public const string ARMAZENAR = "3AR";
        public const string ABASTECER = "4AB";
        public const string VENDER = "5VN";
        public const string ENTREGAR = "6EN";
    }

    public class Grupo
    {
        public const string COMERCIAL = "COM";
        public const string CPD = "CPD";
        public const string FINANCEIRO = "FIN";
        public const string LOGISTICA = "LOG";
        public const string MANUTENCAO = "MAN";
        public const string MARKETING = "MKT";
        public const string OPERACAOLOJA = "OPR";
        public const string RECURSOSHUMANOS = "RHN";
        public const string SERVICOS = "SER";
        public const string VENDAS = "VND";
    }

    public class OrderByTipo
    {
        public const string CRESCENTE = "A";
        public const string DECRESCENTE = "D";
    }

    public class TipoLocal
    {
        public const string CORPORATIVO = "C";
        public const string LOJA = "L";
    }

    public class TipoCargo
    {
        public const string GESTAO = "G";
        public const string OPERACAO = "O";
    }

    public class StatusPedido
    {
        public const string AGUARDANDOPROCESSAMENTO = "A";
        public const string EMFILA = "F";
        public const string JOBATRIBUIDO = "J";
        public const string PROCESSANDO = "E";
        public const string AGUARDANDOFILHOS = "W";
        public const string PROCESSADO = "P";
        public const string SELECIONADO = "T";
        public const string CANCELADO = "C";
    }

    public class StatusProcessamentoPedido
    {
        public const string SUCESSO = "P";
        public const string ERRO = "E";
        public const string AVISO = "A";
    }
}

