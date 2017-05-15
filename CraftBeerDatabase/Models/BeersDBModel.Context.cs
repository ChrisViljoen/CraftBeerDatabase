namespace CraftBeerDatabase.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BeersDBEntities : DbContext
    {
        public BeersDBEntities()
            : base("name=BeersDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Beer> Beers { get; set; }
    
        public virtual int AddBeer(string brewery, string style, string name, string description, Nullable<decimal> aBV, Nullable<int> iBU)
        {
            var breweryParameter = brewery != null ?
                new ObjectParameter("Brewery", brewery) :
                new ObjectParameter("Brewery", typeof(string));
    
            var styleParameter = style != null ?
                new ObjectParameter("Style", style) :
                new ObjectParameter("Style", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var aBVParameter = aBV.HasValue ?
                new ObjectParameter("ABV", aBV) :
                new ObjectParameter("ABV", typeof(decimal));
    
            var iBUParameter = iBU.HasValue ?
                new ObjectParameter("IBU", iBU) :
                new ObjectParameter("IBU", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddBeer", breweryParameter, styleParameter, nameParameter, descriptionParameter, aBVParameter, iBUParameter);
        }
    
        public virtual int EditBeer(Nullable<int> id, string brewery, string style, string name, string description, Nullable<decimal> aBV, Nullable<int> iBU)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var breweryParameter = brewery != null ?
                new ObjectParameter("Brewery", brewery) :
                new ObjectParameter("Brewery", typeof(string));
    
            var styleParameter = style != null ?
                new ObjectParameter("Style", style) :
                new ObjectParameter("Style", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var aBVParameter = aBV.HasValue ?
                new ObjectParameter("ABV", aBV) :
                new ObjectParameter("ABV", typeof(decimal));
    
            var iBUParameter = iBU.HasValue ?
                new ObjectParameter("IBU", iBU) :
                new ObjectParameter("IBU", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditBeer", idParameter, breweryParameter, styleParameter, nameParameter, descriptionParameter, aBVParameter, iBUParameter);
        }
    
        public virtual int RemoveBeer(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RemoveBeer", idParameter);
        }
    }
}
