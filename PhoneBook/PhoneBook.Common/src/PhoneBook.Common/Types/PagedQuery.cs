namespace PhoneBook.Common.Types
{
    public abstract class PagedQuery
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}