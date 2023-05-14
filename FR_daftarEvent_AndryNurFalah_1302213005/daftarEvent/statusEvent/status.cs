namespace daftarEventLibrary
{
    public static class status
    {
        public static String statusEvent(DateTime start, DateTime end)
        {
            DateTime dateTime = DateTime.Now;

            if(dateTime >= start && dateTime < end)
            {
                return "Sedang Berlangsung";
            }else if(dateTime < start)
            {
                return "Terjadwal";
            }
            else
            {
                return "Berakhir";
            }
        }
    }
}