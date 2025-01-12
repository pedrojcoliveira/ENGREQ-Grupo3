namespace AMAPP.Web;

public static class Constants
{
    public enum SubscriptionDuration    { Trimestral,        Semestral}
    public enum ResourceStatus    {  Ativo,     Inativo}

    public enum DeliveryUnit
    {
        Unidade,
        Kg,
        Gramas,
        Litros
    }

    // Payment methods
    public enum PaymentMethod { Dinheiro, MBWay, TransferenciaBancaria }
    // Payment methods
    public enum PaymentMode { Integral, Fracionado }
}