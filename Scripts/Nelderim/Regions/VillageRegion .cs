using System;
using System.Xml;
using Server;

namespace Server.Regions
{
    public class VillageRegion : NelderimRegion
    {
        public VillageRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
        {
        }

        public override bool AllowHousing( Mobile from, Point3D p )
        {
            return false;
        }
        
        public override void OnEnter( Mobile m )
        {
            if ( this.Name != String.Empty )
                m.SendMessage( "Twym oczom ukazuje sie {0}", PrettyName );

            base.OnEnter( m );
        }

        public override void OnExit(Mobile m)
        {
            if ( this.Name != String.Empty )
                m.SendMessage( "Opuszczasz teren {0}", PrettyName );

            base.OnExit(m);
        }
    }
}