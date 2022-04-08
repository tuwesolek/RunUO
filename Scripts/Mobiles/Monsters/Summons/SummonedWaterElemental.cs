using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "zwloki zywiolaka wody" )]
	public class SummonedWaterElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public SummonedWaterElemental () : base( AIType.AI_BattleMage, FightMode.Closest, 12, 1, 0.2, 0.4 )
		{
			Name = "zywiolak wody";
			Body = 16;
			BaseSoundID = 278;

			SetStr( 200 );
			SetDex( 70 );
			SetInt( 100 );

			SetHits( 165 );

			SetDamage( 12, 16 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Cold, 100 );

			SetResistance( ResistanceType.Physical, 50, 60 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 45, 55 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Meditation, 90.0 );
			SetSkill( SkillName.EvalInt, 80.0 );
			SetSkill( SkillName.Magery, 80.0 );
			SetSkill( SkillName.MagicResist, 75.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 85.0 );

			VirtualArmor = 40;
			ControlSlots = 3;
			CanSwim = true;
		}

		public SummonedWaterElemental( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}