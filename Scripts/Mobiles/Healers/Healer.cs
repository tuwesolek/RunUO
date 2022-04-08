using System;
using Server;

namespace Server.Mobiles
{
	public class Healer : BaseHealer
	{
		public override bool CanTeach{ get{ return false; } }

		public override bool CheckTeach( SkillName skill, Mobile from )
		{
			if ( !base.CheckTeach( skill, from ) )
				return false;

            if (!IsAssignedBuildingWorking())
            {
                Say(1063883); // Miasto nie oplacilo moich uslug. Nieczynne.
                return false;
            }
			else
			{
				return true;
			}
		}

		[Constructable]
		public Healer()
		{
			Title = "- uzdrowiciel";

			if ( !Core.AOS )
				NameHue = 0x35;

			SetSkill( SkillName.Zielarstwo, 80.0, 100.0 );
			SetSkill( SkillName.SpiritSpeak, 80.0, 100.0 );
			SetSkill( SkillName.Swords, 80.0, 100.0 );
		}

		public override bool IsActiveVendor{ get{ return true; } }
		public override bool IsInvulnerable{ get{ return true; } }

		public override void InitSBInfo()
		{
			SBInfos.Add( new SBHealer() );
		}

		public override bool CheckResurrect( Mobile m )
		{
            if (!IsAssignedBuildingWorking())
            {
                Say(1063883); // Miasto nie oplacilo moich uslug. Nieczynne.
                return false;
            }
			else if ( m.Criminal )
			{
				Say( 501222 ); // Thou art a criminal.  I shall not resurrect thee.
				return false;
			}
			else if ( m.Kills >= 5 )
			{
				Say( 501223 ); // Thou'rt not a decent and good person. I shall not resurrect thee.
				return false;
			}

			return true;
		}

		public Healer( Serial serial ) : base( serial )
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

			if ( Core.AOS && NameHue == 0x35 )
				NameHue = -1;
		}
	}
}