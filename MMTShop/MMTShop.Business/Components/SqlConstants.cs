namespace MMTShop.Business.Components
{
    public class SqlConstants
    {
        //TODO:MOVE THIS CONNECTION STRING INTO APP SETTINGS
        public static string CONNECTION_STRING = "Data Source=.\\SQLEXPRESS;Initial Catalog=MMTShop;Trusted_Connection=True";
        public static string GET_ALL_CATEGORIES_STORED_PROC =  "sp_getAllCategories";
        public static string GET_ALL_FEATURED_PRODCUTS_STORED_PROC =  "sp_getFeaturedProducts";
        public static string GET_ALL_PRODUCTS_BY_CATEGORY_STORED_PROC =  "sp_getProductsByCategoryId";
    }
}
