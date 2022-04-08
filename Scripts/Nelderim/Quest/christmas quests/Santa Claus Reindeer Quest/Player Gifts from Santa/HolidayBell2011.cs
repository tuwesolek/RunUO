/*
 * Created by SharpDevelop.
 * User: Shazzy
 * Date: 11/30/2005
 * Time: 7:09 AM
 * HolidayBell20052005
 * 
 */
using System;

namespace Server.Items 
{ 
      public class HolidayBell2011 : Item 
      { 
      	
	     public int offset;

             [Constructable] 
             public HolidayBell2011() : base( 0x1c12 ) 
             { 
		     Stackable = false; 
		     Weight = 1.0; 
		     Name = "Swiateczny dzwon 2021";
	         Hue = Utility.RandomBirdHue(); 
		     LootType = LootType.Blessed; 
		     offset = Utility.Random( 0, 10 );
             }

             public HolidayBell2011( Serial serial ) : base( serial ) 
             { 
             } 

	         public override void GetProperties( ObjectPropertyList list )
	         {
	  	    base.GetProperties( list );

		    list.Add( 1007149 + offset ); 
    	     }

             public override void OnDoubleClick( Mobile from ) 
             { 
             	Effects.PlaySound( from, from.Map, 0x505 );
             }

	         public override void Serialize( GenericWriter writer ) 
	         {
	            base.Serialize( writer ); 

	            writer.Write( (int) 0 ); 
	            
	            writer.Write( (int) offset );
	         }
	
	         public override void Deserialize( GenericReader reader ) 
	         {
	            base.Deserialize( reader ); 

	            int version = reader.ReadInt(); 

		        offset = reader.ReadInt();
	         }
      } 
}     
