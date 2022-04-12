namespace ASP.NET_CORE_WEB.Models
{
    public class Pagination
    {
        const int minPageSize = 1;
        const int maxPageSize = 50;
        const int defaultPageSize = 10;

        private int pageNumber = 1;
        public int PageNumber
        {
            get { return pageNumber; }
            set { pageNumber = (value <= 0) ? 1 : value; }
        }

        private int pageSize = 10;
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                if (value < minPageSize)
                    pageSize = defaultPageSize;
                else if (value > maxPageSize)
                    pageSize = maxPageSize;
                else
                    pageSize = value;
            }
        }
    }
}
