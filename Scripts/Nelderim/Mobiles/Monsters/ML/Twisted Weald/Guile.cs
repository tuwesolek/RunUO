using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	public class Guile : Changeling
	{
		public override double DifficultyScalar{ get{ return 1.12; } }
		[Constructable]
		public Guile() : base()
		{
			Name = "Guile";
			Hue = 0x3F;

			SetStr( 53, 214 );
			SetDex( 243, 367 );
			SetInt( 369, 586 );

			SetHits( 1013, 1052 );
			SetStam( 243, 367 );
			SetMana( 369, 586 );

			SetDamage( 14, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 85 );
			SetResistance( ResistanceType.Fire, 46 );
			SetResistance( ResistanceType.Cold, 44 );
			SetResistance( ResistanceType.Poison, 42);
			SetResistance( ResistanceType.Energy, 47 );

			SetSkill( SkillName.Wrestling, 12.8, 16.7);
			SetSkill( SkillName.Tactics, 12.6, 131.0 );
			SetSkill( SkillName.MagicResist, 141.2, 161.6 );
			SetSkill( SkillName.Magery, 80.4, 80.9 );
			SetSkill( SkillName.EvalInt, 80.4, 90.0 );
			SetSkill( SkillName.Meditation, 109.2, 120.0 );
		}

		public Guile( Serial serial ) : base( serial )
		{
		}
		
		//public override bool GivesMinorArtifact{ get{ return true; } }
		
		public override void GenerateLoot()
		{
			AddLoot( LootPack.AosUltraRich, 3 );
			if ( Utility.RandomDouble() < 0.2 )
                PackItem(new TreasureMap(5, Map.Felucca));
				if ( Utility.RandomDouble() < 0.2 )
				PackItem( new Pumice() );
		}
		
    public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
		}
	}
}
