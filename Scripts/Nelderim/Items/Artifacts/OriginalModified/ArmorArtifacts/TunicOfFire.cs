using System;
using Server;

namespace Server.Items
{
	public class TunicOfFire : ChainChest
	{
        public override int LabelNumber { get { return 1061099; } } // Tunika Ognia
        public override int InitMinHits { get { return 50; } }
        public override int InitMaxHits { get { return 50; } }

		public override int BasePhysicalResistance{ get{ return 24; } }
		public override int BaseFireResistance{ get{ return 34; } }

		[Constructable]
		public TunicOfFire()
		{
			Hue = 0x54F;
			Attributes.NightSight = 1;
			Attributes.ReflectPhysical = 15;
			Attributes.RegenStam = 4;
		}

		public TunicOfFire( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version < 1 )
			{
				if ( Hue == 0x54E )
					Hue = 0x54F;

				if ( Attributes.NightSight == 0 )
					Attributes.NightSight = 1;

				PhysicalBonus = 0;
				FireBonus = 0;
			}
		}
	}
}