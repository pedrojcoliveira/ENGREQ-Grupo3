namespace AMAPP.API
{
    public static class Constants
    {
        // Payment methods
        public enum PaymentMethod
        {
            Dinheiro,
            MBWay,
            TransferenciaBancaria,
        }

        // Payment methods
        public enum PaymentMode
        {
            Integral,
            Fracionado
        }

        public enum DeliveryUnit
        {
            Unidade,
            Kg,
            Gramas,
            Litros
        }

        public enum PaymentStatus
        {
            Pendente,
            Pago,
            Cancelado
        }

        // File size limits
        public const int MaxPhotoSizeInBytes = 5 * 1024 * 1024; // 5 MB

        // Valid photo formats
        public static readonly string[] ValidPhotoFormats = { ".jpg", ".jpeg", ".png" };
    }
    
    public enum SubscriptionDuration    {  Trimestral, Semestral    }
    public enum ResourceStatus    {  Ativo,     Inativo}
    
    public static class SubscriptionDurationExtensions
    {
        public static readonly Dictionary<SubscriptionDuration, int> DurationDays = new()
        {
            { SubscriptionDuration.Trimestral, 90 },
            { SubscriptionDuration.Semestral, 180 }
        };

        public static int GetDurationDays(this SubscriptionDuration duration)
        {
            return DurationDays[duration];
        }
    }
}
