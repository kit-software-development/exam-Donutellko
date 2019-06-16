using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
namespace McDonatsClient
{

	/// <summary>
	/// Class represents a menu item that can be added to order.
	/// </summary>
    [DataContract]
    public class Food
    {
        public Food(int FoodId_, string Title_, double Price_, string Desc_ = null)
        {
            this.FoodId = FoodId_;
            this.Title = Title_;
            this.Desc = Desc_;
            this.Price = Price_;
        }

        [DataMember(Name = "foodId")]
        public int FoodId { get; internal set; }

        [DataMember(Name = "title")]
        public string Title { get; internal set; }

        [DataMember(Name = "desc")]
        public string Desc { get; internal set; }

        [DataMember(Name = "price")]
        public double Price { get; internal set; }

		/// <summary>
		/// Maximal count that can be ordered, at the moment of loading. 
		/// The count could have changed since then. 
		/// </summary>
        [DataMember(Name = "count")]
        public double Count { get; internal set; }
    }
}
