namespace lab19.Dto
{
    public static class AddressDtoExtension
    {
        public static string GetOras(this AddressDto addressTransfer) =>
             addressTransfer.Oras;
        public static string GetStrada(this AddressDto addressTransfer) =>
             addressTransfer.Strada;
        public static int GetNumar(this AddressDto addressTransfer) =>
             addressTransfer.Numar;
    }
}
