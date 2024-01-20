using System; 
using System.Collections; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBHerbalist : SBInfo 
	{ 
		private ArrayList m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBHerbalist() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override ArrayList BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : ArrayList 
		{ 
			public InternalBuyInfo() 
			{ 
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 7, 200, 0xF7B, 0 ) ); 
				Add( new GenericBuyInfo( typeof( MandrakeRoot ), 5, 200, 0xF86, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Garlic ), 5, 200, 0xF84, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Ginseng ), 5, 200, 0xF85, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Nightshade ), 5, 200, 0xF88, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Bottle ), 5, 200, 0xF0E, 0 ) ); 
				Add( new GenericBuyInfo( typeof( MortarPestle ), 30, 20, 0xE9B, 0 ) );
				Add( new GenericBuyInfo( typeof( DestroyingAngel ), 8, 50, 0xE1F, 0 ) );
				Add( new GenericBuyInfo( typeof( PetrafiedWood ), 8, 50, 0x97A, 0 ) );
				Add( new GenericBuyInfo( typeof( SpringWater ), 8, 50, 0xE24, 0 ) );
				Add(new GenericBuyInfo("Szufla do lajna", typeof(DungShovel), 30, 50, 0xF39, DungShovel.DefaultHue));
				Add(new GenericBuyInfo("Wiadro na nawoz", typeof(DungBucket), 2000, 5, DungBucket.GraphicsEmpty, DungBucket.HueEmpty));
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( Bloodmoss ), 3 ); 
				Add( typeof( MandrakeRoot ), 2 ); 
				Add( typeof( Garlic ), 2 ); 
				Add( typeof( Ginseng ), 2 ); 
				Add( typeof( Nightshade ), 2 ); 
				Add( typeof( Bottle ), 3 ); 
				Add( typeof( MortarPestle ), 4 );
				Add(typeof(DungShovel), 6);
				Add(typeof(DungBucket), 8);
			} 
		} 
	} 
}