using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace McDonatsClient
{

	/// <summary>
	/// An object that is used to send order to server.
	/// The objecct contains food id and a count to be ordered.
	/// </summary>
	[DataContract]
	class FoodCount
	{
		[DataMember]
		int id;
		[DataMember]
		int count;

		public FoodCount(int id, int count)
		{
			this.id = id;
			this.count = count;
		}
	}

}
