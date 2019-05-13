using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace WebSalt.SqlServerNotifier
{
    public class NotifierEntity
    {
        Dictionary<String, Object> sqlParameters = new Dictionary<String, Object>();

        public String SqlQuery { get; set; }
            
        public String SqlConnectionString { get; set; }
            
        public Dictionary<String, Object> SqlParameters
        {
            get
            {
                return sqlParameters;
            }
            set
            {
                sqlParameters = value;
            }
        }

        public static NotifierEntity FromJson(String value)
        {
            if( String.IsNullOrEmpty(value))
                throw new ArgumentNullException("NotifierEntity Value can not be null!");

            return new JavaScriptSerializer().Deserialize<NotifierEntity>(value);
        }
    }
}