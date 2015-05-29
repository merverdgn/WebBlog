using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebBlog.Models
{
   

        public class Post
        {
            public int ID { get; set; }
            public string TITLE { get; set; }
            public string CONTENT { get; set; }
            public string AUTHOR { get; set; }
            public DateTime CREATEDATE { get; set; }
        }

        public class LocalDBContext : DbContext
        {
            public DbSet<Post> Posts { get; set; }
        }


    
}