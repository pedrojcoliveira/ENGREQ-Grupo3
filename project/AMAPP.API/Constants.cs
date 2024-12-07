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
}
