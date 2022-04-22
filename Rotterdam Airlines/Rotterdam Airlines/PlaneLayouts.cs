using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    internal class PlaneLayouts
    {
        public static string[] getLayout(Flight flight)
        {
            string[] list = new string[13];
            if (flight == null) 
            {
                list = new string[13] {
                    "                ╭────────┰──────────┸────────────────────┸──────────╮                   ╭╯     ╭╯     ",
                    "          ╭─────╯        ┃                                          ╰──────────╮       ╭╯      │      ",
                    "      ╭───╯              ┃                                                     ╰───┰╮ ╭╯      ╭╯      ",
                    "   ╭──╯     ╭╮           ┃                                                         ┃╰─┴────╮  │       ",
                    " ╭─╯      ╭─╯│           ┃                      Uh Oh...                           ┃       ╰──┴╮      ",
                    "╭╯       ╭╯ ╭╯           ┃                                                         ┃           ╰╮     ",
                    "│        │  │            ┃           Er is geen vlucht geselecteerd!               ┃    ════════╪═════",
                    "╰╮       ╰╮ ╰╮           ┃                                                         ┃           ╭╯     ",
                    " ╰─╮      ╰─╮│           ┃           Selecteer eerst een vlucht om                 ┃       ╭──┬╯      ",
                    "   ╰──╮     ╰╯           ┃           stoelen uit te kiezen!                        ┃╭─┬────╯  │       ",
                    "      ╰───╮              ┃                                                     ╭───┸╯ ╰╮      ╰╮      ",
                    "          ╰─────╮        ┃                                          ╭──────────╯       ╰╮      │      ",
                    "                ╰────────┸──────────┰────────────────────┰──────────╯                   ╰╮     ╰╮     "
                };
            }
            else if (flight.PlaneType == "Boeing 737")
            {
                list = new string[13] {
                    "                ╭────────┰────═────────────────────────────────────┸─────────═────═────────┸───────────────────────────────────╮                           ╭╯     ╭╯     ",
                    "          ╭─────╯        ┃    ▲                                              ▲    ▲                                            ╰─────────────═──╮         ╭╯      │      ",
                    "      ╭───╯              ┃            A1 A2 A3 A4 A5 A6 A7 A8 A9 Aa Ab Ac Ad   G0   G1 G2 G3 G4 G5 G6 G7 G8 G9 Ga Gb Gc Gd Ge Gf Gg Gh ╭───╮ ▲  ╰─────┰╮ ╭╯      ╭╯      ",
                    "   ╭──╯     ╭╮           ┃            B1 B2 B3 B4 B5 B6 B7 B8 B9 Ba Bb Bc Bd   H0   H1 H2 H3 H4 H5 H6 H7 H8 H9 Ha Hb Hc Hd He Hf Hg Hh │   │          ┃╰─┴────╮  │       ",
                    " ╭─╯      ╭─╯│           ┃            C1 C2 C3 C4 C5 C6 C7 C8 C9 Ca Cb Cc Cd   I0   I1 I2 I3 I4 I5 I6 I7 I8 I9 Ia Ib Ic Id Ie If Ig Ih ╰───╯          ┃       ╰──┴╮      ",
                    "╭╯       ╭╯ ╭╯           ┃                                                                                                                            ┃           ╰╮     ",
                    "│        │  │            ┃                                                                                                                            ┃    ════════╪═════",
                    "╰╮       ╰╮ ╰╮           ┃                                                                                                                            ┃           ╭╯     ",
                    " ╰─╮      ╰─╮│           ┃  ╭───╮  D0 D1 D2 D3 D4 D5 D6 D7 D8 D9 Da Db Dc Dd   J0   J1 J2 J3 J4 J5 J6 J7 J8 J9 Ja Jb Jc Jd Je Jf Jg Jh ╭───╮          ┃       ╭──┬╯      ",
                    "   ╰──╮     ╰╯           ┃  │   │  E0 E1 E2 E3 E4 E5 E6 E7 E8 E9 Ea Eb Ec Ed   K0   K1 K2 K3 K4 K5 K6 K7 K8 K9 Ka Kb Kc Kd Ke Kf Kg Kh │   │          ┃╭─┬────╯  │       ",
                    "      ╰───╮              ┃  ╰───╯  F0 F1 F2 F3 F4 F5 F6 F7 F8 F9 Fa Fb Fc Fd   L0   L1 L2 L3 L4 L5 L6 L7 L8 L9 La Lb Lc Ld Le Lf Lg Lh ╰───╯ ▼  ╭─────┸╯ ╰╮      ╰╮      ",
                    "          ╰─────╮        ┃    ▼                                              ▼    ▼                                            ╭─────────────═──╯         ╰╮      │      ",
                    "                ╰────────┸────═────────────────────────────────────┰─────────═────═────────┰───────────────────────────────────╯                           ╰╮     ╰╮     ",
                };
            }
            else if (flight.PlaneType == "Airbus 330")
            {
                list = new string[13] {
                    "                ╭─────═──┰───────────────────────────═──────────────────────┸─────────────────────────────────┸───────┬─═───────────────────────────╮                           ╭╯     ╭╯     ",
                    "          ╭─────╯     ▲  ┃         XX XX XX XX ╭───╮ ▲  XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX ╭───╮│ ▲  XX XX XX XX XX XX XX XX  ╰────────────────╮         ╭╯      │      ",
                    "      ╭───╯              ┃  XX XX  XX XX XX XX │   │    XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX │   ││    XX XX XX XX XX XX XX XX  XX XX XX XX XX XX╰──═──┰╮ ╭╯      ╭╯      ",
                    "   ╭──╯     ╭╮           ┃  XX XX  XX XX XX XX ╰───╯    XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX ╰───╯╵    XX XX XX XX XX XX XX XX  XX XX XX XX XX XX   ▲  ┃╰─┴────╮  │       ",
                    " ╭─╯      ╭─╯│           ┃                                                                                         ╭───╮                                                   ┃       ╰──┴╮      ",
                    "╭╯       ╭╯ ╭╯           ┃  XX XX   XX XX XX XX XX XX  XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX │   │  XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX     ┃           ╰╮     ",
                    "│        │  │            ┃  XX XX   XX XX XX XX XX XX  XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX ├───┤  XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX     ┃    ════════╪═════",
                    "╰╮       ╰╮ ╰╮           ┃          XX XX XX XX XX XX  XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX │   │  XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX     ┃           ╭╯     ",
                    " ╰─╮      ╰─╮│           ┃                                                                                         ╰───╯                                                   ┃       ╭──┬╯      ",
                    "   ╰──╮     ╰╯           ┃  XX XX  XX XX XX XX ╭───╮    XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX ╭───╮╷    XX XX XX XX XX XX XX XX  XX XX XX XX XX XX   ▼  ┃╭─┬────╯  │       ",
                    "      ╰───╮              ┃  XX XX  XX XX XX XX │   │    XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX │   ││    XX XX XX XX XX XX XX XX  XX XX XX XX XX XX╭──═──┸╯ ╰╮      ╰╮      ",
                    "          ╰─────╮     ▼  ┃         XX XX XX XX ╰───╯ ▼  XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX ╰───╯│ ▼  XX XX XX XX XX XX XX XX  ╭────────────────╯         ╰╮      │      ",
                    "                ╰─────═──┸───────────────────────────═──────────────────────┰─────────────────────────────────┰───────┴─═───────────────────────────╯                           ╰╮     ╰╮     ",
                };
            }
            else if (flight.PlaneType == "Boeing 787")
            {
                list = new string[13] {
                    "                ╭─────═──┰───────────────────────═─┬────┸──────┬────────────────────────────────┸─────═────────────────────────────────┬───────═─╮                   ╭╯     ╭╯     ",
                    "          ╭─────╯     ▲  ┃╭───╮            ╭───╮ ▲ │           │ XX XX XX XX XX XX XX XX XX XX ╭───╮  ▲  XX XX XX XX XX XX XX XX XX XX │ ╭───╮ ▲ ╰──────────╮       ╭╯      │      ",
                    "      ╭───╯              ┃│   │  XX XX XX  │   │   │ XX XX XX  │ XX XX XX XX XX XX XX XX XX XX │   │     XX XX XX XX XX XX XX XX XX XX │ │   │              ╰───┰╮ ╭╯      ╭╯      ",
                    "   ╭──╯     ╭╮           ┃│   │  XX XX XX  ╰───╯   ╵ XX XX XX  ╵ XX XX XX XX XX XX XX XX XX XX ╰───╯     XX XX XX XX XX XX XX XX XX XX ╵ ╰───╯                  ┃╰─┴────╮  │       ",
                    " ╭─╯      ╭─╯│           ┃╰───╯                                                                                                                                 ┃       ╰──┴╮      ",
                    "╭╯       ╭╯ ╭╯           ┃    ╷    XX XX XX            XX XX XX    XX XX XX XX XX XX XX XX XX ╷         XX XX XX XX XX XX XX XX XX XX XX XX                     ┃           ╰╮     ",
                    "│        │  │            ┃    │    XX XX XX            XX XX XX    XX XX XX XX XX XX XX XX XX │         XX XX XX XX XX XX XX XX XX XX XX XX                     ┃    ════════╪═════",
                    "╰╮       ╰╮ ╰╮           ┃    ╵                                    XX XX XX XX XX XX XX XX XX ╵         XX XX XX XX XX XX XX XX XX XX XX XX                     ┃           ╭╯     ",
                    " ╰─╮      ╰─╮│           ┃                                                                                                                                      ┃       ╭──┬╯      ",
                    "   ╰──╮     ╰╯           ┃       XX XX XX  ╭───╮   ╷ XX XX XX  ╷ XX XX XX XX XX XX XX XX XX XX ╭───╮     XX XX XX XX XX XX XX XX XX XX ╷ ╭───╮                  ┃╭─┬────╯  │       ",
                    "      ╰───╮              ┃       XX XX XX  │   │   │ XX XX XX  │ XX XX XX XX XX XX XX XX XX XX │   │     XX XX XX XX XX XX XX XX XX XX │ │   │              ╭───┸╯ ╰╮      ╰╮      ",
                    "          ╰─────╮     ▼  ┃                 ╰───╯ ▼ │           │ XX XX XX XX XX XX XX XX XX XX ╰───╯  ▼  XX XX XX XX XX XX XX XX XX XX │ ╰───╯ ▼ ╭──────────╯       ╰╮      │      ",
                    "                ╰─────═──┸───────────────────────═─┴────┰──────┴────────────────────────────────┰─────═────────────────────────────────┴───────═─╯                   ╰╮     ╰╮     ",
                };
            }
            return list;
        }
    }
}
