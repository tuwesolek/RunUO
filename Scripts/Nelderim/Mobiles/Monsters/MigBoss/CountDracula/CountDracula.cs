using System;
using Server;
using Server.Items;
using Server.Spells;
using Server.Spells.Seventh;
using Server.Spells.Fifth;
using Server.Engines.CannedEvil;
using Server.Engines.XmlSpawner2;

namespace Server.Mobiles
{
	public class CountDracula : BaseCreature
	{

		[Constructable]
		public CountDracula() : base( AIType.AI_Boss, FightMode.Closest, 12, 1, 0.2, 0.4 )
		{
			Name = "Wyższy Wampir";
		    Body = 0x190;
			

			SetStr( 305, 425 );
			SetDex( 72, 150 );
			SetInt( 505, 750 );

			SetHits( 8000 );
			SetStam( 102, 300 );

			SetDamage( 20, 30 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 60, 70 );
			SetResistance( ResistanceType.Fire, 50, 60 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.MagicResist, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 97.6, 100.0 );
			SetSkill( SkillName.Necromancy, 97.6, 100.0 );
			SetSkill( SkillName.SpiritSpeak, 100.0, 100.0 );

			Fame = 22500;
			Karma = -22500;

			VirtualArmor = 70;

			AddItem( new FancyShirt() );
			AddItem( new LongPants() );
			AddItem( new BodySash( Utility.RandomRedHue() ) );
			AddItem( new Cloak( Utility.RandomBlueHue() ) );
			AddItem( new Boots() );
			
			XmlLifeDrain lifeDrainAttachment = new XmlLifeDrain(20, 5); 
			XmlAttach.AttachTo(this, lifeDrainAttachment);
        }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 3 );
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool AutoDispel{ get{ return true; } }
		public override double AutoDispelChance{ get{ return 1.0; } }
		public override bool BardImmune{ get{ return !Core.SE; } }
		public override bool Unprovokable{ get{ return Core.SE; } }
		public override bool Uncalmable{ get{ return Core.SE; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }

		public override bool ShowFameTitle{ get{ return false; } }
		public override bool ClickTitle{ get{ return false; } }

		public void Polymorph( Mobile m )
		{
			if ( !m.CanBeginAction( typeof( PolymorphSpell ) ) || !m.CanBeginAction( typeof( IncognitoSpell ) ) || m.IsBodyMod )
				return;

			IMount mount = m.Mount;

			if ( mount != null )
				mount.Rider = null;

			if ( m.Mounted )
				return;

			if ( m.BeginAction( typeof( PolymorphSpell ) ) )
			{
				Item disarm = m.FindItemOnLayer( Layer.OneHanded );

				if ( disarm != null && disarm.Movable )
					m.AddToBackpack( disarm );

				disarm = m.FindItemOnLayer( Layer.TwoHanded );

				if ( disarm != null && disarm.Movable )
					m.AddToBackpack( disarm );

				m.BodyMod = 317;
				m.HueMod = 0;

				new ExpirePolymorphTimer( m ).Start();
			}
		}

		private class ExpirePolymorphTimer : Timer
		{
			private Mobile m_Owner;

			public ExpirePolymorphTimer( Mobile owner ) : base( TimeSpan.FromMinutes( 3.0 ) )
			{
				m_Owner = owner;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if ( !m_Owner.CanBeginAction( typeof( PolymorphSpell ) ) )
				{
					m_Owner.BodyMod = 0;
					m_Owner.HueMod = -1;
					m_Owner.EndAction( typeof( PolymorphSpell ) );
				}
			}
		}

		

		public void DoSpecialAbility( Mobile target )
		{
			if ( target == null || target.Deleted ) //sanity
				return;
			if ( 0.6 >= Utility.RandomDouble() ) // 60% chance to polymorph attacker into a Vampire bat
				Polymorph( target );
            if ( Hits < 500 && !IsBodyMod ) // Baracoon is low on life, polymorph into a ratman
				Polymorph( this );
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			DoSpecialAbility( attacker );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			DoSpecialAbility( defender );
		}

		public CountDracula( Serial serial ) : base( serial )
		{
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