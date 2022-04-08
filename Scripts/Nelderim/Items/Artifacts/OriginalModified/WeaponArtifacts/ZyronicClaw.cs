using System;
using Server;

namespace Server.Items
{
	public class ZyronicClaw : ExecutionersAxe
	{
		public override int LabelNumber{ get{ return 1061593; } } // Krwawy Kiel
		public override int InitMinHits{ get{ return 60; } }
		public override int InitMaxHits{ get{ return 60; } }

		[Constructable]
		public ZyronicClaw()
		{
			Hue = 0x485;
			Slayer = SlayerName.ElementalBan;
			WeaponAttributes.HitLeechMana = 50;
			Attributes.AttackChance = 30;
			Attributes.WeaponDamage = 50;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy )
		{
			phys = fire = cold = pois = nrgy = 20;
		}

		public ZyronicClaw( Serial serial ) : base( serial )
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

			if ( Slayer == SlayerName.None )
				Slayer = SlayerName.ElementalBan;
		}
	}
}