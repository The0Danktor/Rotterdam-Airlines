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
                    "          ╭─────╯     ▲  ┃         G0 G1 G2 G3 ╭───╮ ▲  P0 P1 P2 P3 P4 P5 P6 P7 P8 P9 Pa Pb Pc Pd Pe Pf Pg Ph Pi ╭───╮│ ▲  a0 a1 a2 a3 a4 a5 a6 a7  ╰────────────────╮         ╭╯      │      ",
                    "      ╭───╯              ┃  A0 A1  H0 H1 H2 H3 │   │    Q0 Q1 Q2 Q3 Q4 Q5 Q6 Q7 Q8 Q9 Qa Qb Qc Qd Qe Qf Qg Qh Qi │   ││    b0 b1 b2 b3 b4 b5 b6 b7  j0 j1 j2 j3 j4 j5╰──═──┰╮ ╭╯      ╭╯      ",
                    "   ╭──╯     ╭╮           ┃  B0 B1  I0 I1 I2 I3 ╰───╯    R0 R1 R2 R3 R4 R5 R6 R7 R8 R9 Ra Rb Rc Rd Re Rf Rg Rh Ri ╰───╯╵    c0 c1 c2 c3 c4 c5 c6 c7  k0 k1 k2 k3 k4 k5   ▲  ┃╰─┴────╮  │       ",
                    " ╭─╯      ╭─╯│           ┃                                                                                         ╭───╮                                                   ┃       ╰──┴╮      ",
                    "╭╯       ╭╯ ╭╯           ┃  C0 C1   J0 J1 J2 J3 J4 J5  S0 S1 S2 S3 S4 S5 S6 S7 S8 S9 Sa Sb Sc Sd Se Sf Sg Sh Si Sj │   │  d0 d1 d2 d3 d4 d5 d6 d7 d8 d9 da db dc dd de     ┃           ╰╮     ",
                    "│        │  │            ┃  D0 D1   K0 K1 K2 K3 K4 K5  T0 T1 T2 T3 T4 T5 T6 T7 T8 T9 Ta Tb Tc Td Te Tf Tg Th Ti Tj ├───┤  e0 e1 e2 e3 e4 e5 e6 e7 e8 e9 ea eb ec ed ee     ┃    ════════╪═════",
                    "╰╮       ╰╮ ╰╮           ┃          L0 L1 L2 L3 L4 L5  U0 U1 U2 U3 U4 U5 U6 U7 U8 U9 Ua Ub Uc Ud Ue Uf Ug Uh Ui Uj │   │  f0 f1 f2 f3 f4 f5 f6 f7 f8 f9 fa fb fc fd fe     ┃           ╭╯     ",
                    " ╰─╮      ╰─╮│           ┃                                                                                         ╰───╯                                                   ┃       ╭──┬╯      ",
                    "   ╰──╮     ╰╯           ┃  E0 E1  M0 M1 M2 M3 ╭───╮    V0 V1 V2 V3 V4 V5 V6 V7 V8 V9 Va Vb Vc Vd Ve Vf Vg Vh Vi ╭───╮╷    g0 g1 g2 g3 g4 g5 g6 g7  l0 l1 l2 l3 l4 l5   ▼  ┃╭─┬────╯  │       ",
                    "      ╰───╮              ┃  F0 F1  N0 N1 N2 N3 │   │    W0 W1 W2 W3 W4 W5 W6 W7 W8 W9 Wa Wb Wc Wd We Wf Wg Wh Wi │   ││    h0 h1 h2 h3 h4 h5 h6 h7  m0 m1 m2 m3 m4 m5╭──═──┸╯ ╰╮      ╰╮      ",
                    "          ╰─────╮     ▼  ┃         O0 O1 O2 O3 ╰───╯ ▼  X0 X1 X2 X3 X4 X5 X6 X7 X8 X9 Xa Xb Xc Xd Xe Xf Xg Xh Xi ╰───╯│ ▼  i0 i1 i2 i3 i4 i5 i6 i7  ╭────────────────╯         ╰╮      │      ",
                    "                ╰─────═──┸───────────────────────────═──────────────────────┰─────────────────────────────────┰───────┴─═───────────────────────────╯                           ╰╮     ╰╮     ",
                };
            }
            else if (flight.PlaneType == "Boeing 787")
            {
                list = new string[13] {
                    "                ╭─────═──┰───────────────────────═─┬────┸──────┬────────────────────────────────┸─────═────────────────────────────────┬───────═─╮                   ╭╯     ╭╯     ",
                    "          ╭─────╯     ▲  ┃╭───╮            ╭───╮ ▲ │           │ G0 G1 G2 G3 G4 G5 G6 G7 G8 G9 ╭───╮  ▲  P0 P1 P2 P3 P4 P5 P6 P7 P8 P9 │ ╭───╮ ▲ ╰──────────╮       ╭╯      │      ",
                    "      ╭───╯              ┃│   │  A0 A1 A2  │   │   │ A3 A4 A5  │ H0 H1 H2 H3 H4 H5 H6 H7 H8 H9 │   │     Q0 Q1 Q2 Q3 Q4 Q5 Q6 Q7 Q8 Q9 │ │   │              ╰───┰╮ ╭╯      ╭╯      ",
                    "   ╭──╯     ╭╮           ┃│   │  B0 B1 B2  ╰───╯   ╵ B3 B4 B5  ╵ I0 I1 I2 I3 I4 I5 I6 I7 I8 I9 ╰───╯     R0 R1 R2 R3 R4 R5 R6 R7 R8 R9 ╵ ╰───╯                  ┃╰─┴────╮  │       ",
                    " ╭─╯      ╭─╯│           ┃╰───╯                                                                                                                                 ┃       ╰──┴╮      ",
                    "╭╯       ╭╯ ╭╯           ┃    ╷    C0 C1 C2            C3 C4 C5    J0 J1 J2 J3 J4 J5 J6 J7 J8 ╷         S0 S1 S2 S3 S4 S5 S6 S7 S8 S9 Sa Sb                     ┃           ╰╮     ",
                    "│        │  │            ┃    │    D0 D1 D2            D3 D4 D5    K0 K1 K2 K3 K4 K5 K6 K7 K8 │         T0 T1 T2 T3 T4 T5 T6 T7 T8 T9 Ta Tb                     ┃    ════════╪═════",
                    "╰╮       ╰╮ ╰╮           ┃    ╵                                    L0 L1 L2 L3 L4 L5 L6 L7 L8 ╵         U0 U1 U2 U3 U4 U5 U6 U7 U8 U9 Ua Ub                     ┃           ╭╯     ",
                    " ╰─╮      ╰─╮│           ┃                                                                                                                                      ┃       ╭──┬╯      ",
                    "   ╰──╮     ╰╯           ┃       E0 E1 E2  ╭───╮   ╷ E3 E4 E5  ╷ M0 M1 M2 M3 M4 M5 M6 M7 M8 M9 ╭───╮     V0 V1 V2 V3 V4 V5 V6 V7 V8 V9 ╷ ╭───╮                  ┃╭─┬────╯  │       ",
                    "      ╰───╮              ┃       F0 F1 F2  │   │   │ F3 F4 F5  │ N0 N1 N2 N3 N4 N5 N6 N7 N8 N9 │   │     W0 W1 W2 W3 W4 W5 W6 W7 W8 W9 │ │   │              ╭───┸╯ ╰╮      ╰╮      ",
                    "          ╰─────╮     ▼  ┃                 ╰───╯ ▼ │           │ O0 O1 O2 O3 O4 O5 O6 O7 O8 O9 ╰───╯  ▼  X0 X1 X2 X3 X4 X5 X6 X7 X8 X9 │ ╰───╯ ▼ ╭──────────╯       ╰╮      │      ",
                    "                ╰─────═──┸───────────────────────═─┴────┰──────┴────────────────────────────────┰─────═────────────────────────────────┴───────═─╯                   ╰╮     ╰╮     ",
                };
            }
            return list;
        }
    }
}
