namespace daftarEventLibraries
{
    public static class statusEvent
    {
        public static String cekStatus(DateTime start , DateTime end)
        {
            DateTime t = DateTime.Now;
            if(start >= t && t < end)
            {
                return "Terjadwal";
            }
            else if(t < start)
            {
                return "Sedang Berlangsung";
            }
            else
            {
                return "Selesai";
            }
        }
    }
}