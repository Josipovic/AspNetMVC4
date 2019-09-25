using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPNet5.Models
{
    public class ArticleExContext:DbContext
    {
        public  DbSet<ArticleEx>Articles { get; set; }

        public System.Data.Entity.DbSet<ASPNet5.Models.Zaposlenik> Zaposleniks { get; set; }
    }
}