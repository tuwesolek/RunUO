using System;
using Server;

namespace Server.Items
{
	public class LeggingsOfEmbers : PlateLegs
	{


		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 25; } }
		public override int BaseColdResistance{ get{ return 0; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 15; } }

		public override int InitMinHits{ get{ return 60; } }
		public override int InitMaxHits{ get{ return 60; } }

		[Constructable]
		public LeggingsOfEmbers()
		{
			Hue = 0x2C;
			Name = "Królewskie Nogawnice Ogni Piekielnych";
			LootType = LootType.Regular;


			ArmorAttributes.MageArmor = 1;
			ArmorAttributes.LowerStatReq = 100;
		}

		public LeggingsOfEmbers( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}