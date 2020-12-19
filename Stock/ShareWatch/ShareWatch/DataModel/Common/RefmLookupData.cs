namespace ShareWatch.DataModels.Common
{
    /// <summary>
    /// Look up class to store the REFM data
    /// </summary>
    public class RefmLookupData
    {
        public RefmLookupData(string code, string description)
        {
            this.Code = code;
            this.Description = description;
        }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}