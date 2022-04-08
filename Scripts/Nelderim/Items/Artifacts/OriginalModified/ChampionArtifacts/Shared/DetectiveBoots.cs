using System;
using Server;

namespace Server.Items
{
	public class DetectiveBoots : Boots
	{
        public override int LabelNumber { get { return 1065836; } } // Buty Krolewskiego Sledczego

		public override int InitMinHits{ get{ return 20; } }
		public override int InitMaxHits{ get{ return 20; } }

		public override bool CanFortify{ get{ return true; } }

		private int m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Level
		{
			get{ return m_Level; }
			set{ m_Level = Math.Max( Math.Min( 2, value), 0 ); Attributes.BonusInt = 2 + m_Level; InvalidateProperties(); }
		}

		[Constructable]
		public DetectiveBoots()
		{
			Hue = 0x455;
			Level = Utility.RandomMinMax( 0, 2 );
		}

		public DetectiveBoots( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			Level = Attributes.BonusInt - 2;
		}
	}
}
