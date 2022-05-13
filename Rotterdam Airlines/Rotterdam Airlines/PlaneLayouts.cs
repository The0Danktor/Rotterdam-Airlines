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

        public static List<Seat> CreateSeatList(Flight flightObj)
        {
            string flight = flightObj.FlightCode;
            List<Seat> seats = new List<Seat>();
            string planeType = flightObj.PlaneType;
            switch (planeType)
            {
                case "Boeing 737": // ------------------------------------------------------- Boeing 737
                    seats.Add(new Seat("A1", "business", "normal", flight));
                    seats.Add(new Seat("A2", "business", "normal", flight));
                    seats.Add(new Seat("A3", "business", "normal", flight));
                    seats.Add(new Seat("A4", "business", "normal", flight));
                    seats.Add(new Seat("A5", "business", "normal", flight));
                    seats.Add(new Seat("A6", "business", "normal", flight));
                    seats.Add(new Seat("A7", "business", "normal", flight));
                    seats.Add(new Seat("A8", "business", "normal", flight));
                    seats.Add(new Seat("A9", "business", "normal", flight));
                    seats.Add(new Seat("Aa", "economy", "normal", flight));
                    seats.Add(new Seat("Ab", "economy", "normal", flight));
                    seats.Add(new Seat("Ac", "economy", "normal", flight));
                    seats.Add(new Seat("Ad", "economy", "limited recline", flight));

                    seats.Add(new Seat("B1", "business", "normal", flight));
                    seats.Add(new Seat("B2", "business", "normal", flight));
                    seats.Add(new Seat("B3", "business", "normal", flight));
                    seats.Add(new Seat("B4", "business", "normal", flight));
                    seats.Add(new Seat("B5", "business", "normal", flight));
                    seats.Add(new Seat("B6", "business", "normal", flight));
                    seats.Add(new Seat("B7", "business", "normal", flight));
                    seats.Add(new Seat("B8", "business", "normal", flight));
                    seats.Add(new Seat("B9", "business", "normal", flight));
                    seats.Add(new Seat("Ba", "economy", "normal", flight));
                    seats.Add(new Seat("Bb", "economy", "normal", flight));
                    seats.Add(new Seat("Bc", "economy", "normal", flight));
                    seats.Add(new Seat("Bd", "economy", "limited recline", flight));

                    seats.Add(new Seat("C1", "business", "normal", flight));
                    seats.Add(new Seat("C2", "business", "normal", flight));
                    seats.Add(new Seat("C3", "business", "normal", flight));
                    seats.Add(new Seat("C4", "business", "normal", flight));
                    seats.Add(new Seat("C5", "business", "normal", flight));
                    seats.Add(new Seat("C6", "business", "normal", flight));
                    seats.Add(new Seat("C7", "business", "normal", flight));
                    seats.Add(new Seat("C8", "business", "normal", flight));
                    seats.Add(new Seat("C9", "business", "normal", flight));
                    seats.Add(new Seat("Ca", "economy", "normal", flight));
                    seats.Add(new Seat("Cb", "economy", "normal", flight));
                    seats.Add(new Seat("Cc", "economy", "normal", flight));
                    seats.Add(new Seat("Cd", "economy", "limited recline", flight));

                    seats.Add(new Seat("D0", "business", "limited legroom", flight));
                    seats.Add(new Seat("D1", "business", "normal", flight));
                    seats.Add(new Seat("D2", "business", "normal", flight));
                    seats.Add(new Seat("D3", "business", "normal", flight));
                    seats.Add(new Seat("D4", "business", "normal", flight));
                    seats.Add(new Seat("D5", "business", "normal", flight));
                    seats.Add(new Seat("D6", "business", "normal", flight));
                    seats.Add(new Seat("D7", "business", "normal", flight));
                    seats.Add(new Seat("D8", "business", "normal", flight));
                    seats.Add(new Seat("D9", "business", "normal", flight));
                    seats.Add(new Seat("Da", "economy", "normal", flight));
                    seats.Add(new Seat("Db", "economy", "normal", flight));
                    seats.Add(new Seat("Dc", "economy", "normal", flight));
                    seats.Add(new Seat("Dd", "economy", "limited recline", flight));

                    seats.Add(new Seat("E0", "business", "limited legroom", flight));
                    seats.Add(new Seat("E1", "business", "normal", flight));
                    seats.Add(new Seat("E2", "business", "normal", flight));
                    seats.Add(new Seat("E3", "business", "normal", flight));
                    seats.Add(new Seat("E4", "business", "normal", flight));
                    seats.Add(new Seat("E5", "business", "normal", flight));
                    seats.Add(new Seat("E6", "business", "normal", flight));
                    seats.Add(new Seat("E7", "business", "normal", flight));
                    seats.Add(new Seat("E8", "business", "normal", flight));
                    seats.Add(new Seat("E9", "business", "normal", flight));
                    seats.Add(new Seat("Ea", "economy", "normal", flight));
                    seats.Add(new Seat("Eb", "economy", "normal", flight));
                    seats.Add(new Seat("Ec", "economy", "normal", flight));
                    seats.Add(new Seat("Ed", "economy", "limited recline", flight));

                    seats.Add(new Seat("F0", "business", "limited legroom", flight));
                    seats.Add(new Seat("F1", "business", "normal", flight));
                    seats.Add(new Seat("F2", "business", "normal", flight));
                    seats.Add(new Seat("F3", "business", "normal", flight));
                    seats.Add(new Seat("F4", "business", "normal", flight));
                    seats.Add(new Seat("F5", "business", "normal", flight));
                    seats.Add(new Seat("F6", "business", "normal", flight));
                    seats.Add(new Seat("F7", "business", "normal", flight));
                    seats.Add(new Seat("F8", "business", "normal", flight));
                    seats.Add(new Seat("F9", "business", "normal", flight));
                    seats.Add(new Seat("Fa", "economy", "normal", flight));
                    seats.Add(new Seat("Fb", "economy", "normal", flight));
                    seats.Add(new Seat("Fc", "economy", "normal", flight));
                    seats.Add(new Seat("Fd", "economy", "limited recline", flight));

                    seats.Add(new Seat("G0", "economy", "increased legroom, limited recline", flight));
                    seats.Add(new Seat("G1", "economy", "increased legroom", flight));
                    seats.Add(new Seat("G2", "economy", "normal", flight));
                    seats.Add(new Seat("G3", "economy", "normal", flight));
                    seats.Add(new Seat("G4", "economy", "normal", flight));
                    seats.Add(new Seat("G5", "economy", "normal", flight));
                    seats.Add(new Seat("G6", "economy", "normal", flight));
                    seats.Add(new Seat("G7", "economy", "normal", flight));
                    seats.Add(new Seat("G8", "economy", "normal", flight));
                    seats.Add(new Seat("G9", "economy", "normal", flight));
                    seats.Add(new Seat("Ga", "economy", "normal", flight));
                    seats.Add(new Seat("Gb", "economy", "normal", flight));
                    seats.Add(new Seat("Gc", "economy", "normal", flight));
                    seats.Add(new Seat("Gd", "economy", "normal", flight));
                    seats.Add(new Seat("Ge", "economy", "normal", flight));
                    seats.Add(new Seat("Gf", "economy", "normal", flight));
                    seats.Add(new Seat("Gg", "economy", "normal", flight));
                    seats.Add(new Seat("Gh", "economy", "limited recline", flight));

                    seats.Add(new Seat("H0", "economy", "increased legroom, limited recline", flight));
                    seats.Add(new Seat("H1", "economy", "increased legroom", flight));
                    seats.Add(new Seat("H2", "economy", "normal", flight));
                    seats.Add(new Seat("H3", "economy", "normal", flight));
                    seats.Add(new Seat("H4", "economy", "normal", flight));
                    seats.Add(new Seat("H5", "economy", "normal", flight));
                    seats.Add(new Seat("H6", "economy", "normal", flight));
                    seats.Add(new Seat("H7", "economy", "normal", flight));
                    seats.Add(new Seat("H8", "economy", "normal", flight));
                    seats.Add(new Seat("H9", "economy", "normal", flight));
                    seats.Add(new Seat("Ha", "economy", "normal", flight));
                    seats.Add(new Seat("Hb", "economy", "normal", flight));
                    seats.Add(new Seat("Hc", "economy", "normal", flight));
                    seats.Add(new Seat("Hd", "economy", "normal", flight));
                    seats.Add(new Seat("He", "economy", "normal", flight));
                    seats.Add(new Seat("Hf", "economy", "normal", flight));
                    seats.Add(new Seat("Hg", "economy", "normal", flight));
                    seats.Add(new Seat("Hh", "economy", "limited recline", flight));

                    seats.Add(new Seat("I0", "economy", "increased legroom, limited recline", flight));
                    seats.Add(new Seat("I1", "economy", "increased legroom", flight));
                    seats.Add(new Seat("I2", "economy", "normal", flight));
                    seats.Add(new Seat("I3", "economy", "normal", flight));
                    seats.Add(new Seat("I4", "economy", "normal", flight));
                    seats.Add(new Seat("I5", "economy", "normal", flight));
                    seats.Add(new Seat("I6", "economy", "normal", flight));
                    seats.Add(new Seat("I7", "economy", "normal", flight));
                    seats.Add(new Seat("I8", "economy", "normal", flight));
                    seats.Add(new Seat("I9", "economy", "normal", flight));
                    seats.Add(new Seat("Ia", "economy", "normal", flight));
                    seats.Add(new Seat("Ib", "economy", "normal", flight));
                    seats.Add(new Seat("Ic", "economy", "normal", flight));
                    seats.Add(new Seat("Id", "economy", "normal", flight));
                    seats.Add(new Seat("Ie", "economy", "normal", flight));
                    seats.Add(new Seat("If", "economy", "normal", flight));
                    seats.Add(new Seat("Ig", "economy", "normal", flight));
                    seats.Add(new Seat("Ih", "economy", "limited recline", flight));

                    seats.Add(new Seat("J0", "economy", "increased legroom, limited recline", flight));
                    seats.Add(new Seat("J1", "economy", "increased legroom", flight));
                    seats.Add(new Seat("J2", "economy", "normal", flight));
                    seats.Add(new Seat("J3", "economy", "normal", flight));
                    seats.Add(new Seat("J4", "economy", "normal", flight));
                    seats.Add(new Seat("J5", "economy", "normal", flight));
                    seats.Add(new Seat("J6", "economy", "normal", flight));
                    seats.Add(new Seat("J7", "economy", "normal", flight));
                    seats.Add(new Seat("J8", "economy", "normal", flight));
                    seats.Add(new Seat("J9", "economy", "normal", flight));
                    seats.Add(new Seat("Ja", "economy", "normal", flight));
                    seats.Add(new Seat("Jb", "economy", "normal", flight));
                    seats.Add(new Seat("Jc", "economy", "normal", flight));
                    seats.Add(new Seat("Jd", "economy", "normal", flight));
                    seats.Add(new Seat("Je", "economy", "normal", flight));
                    seats.Add(new Seat("Jf", "economy", "normal", flight));
                    seats.Add(new Seat("Jg", "economy", "normal", flight));
                    seats.Add(new Seat("Jh", "economy", "limited recline", flight));

                    seats.Add(new Seat("K0", "economy", "increased legroom, limited recline", flight));
                    seats.Add(new Seat("K1", "economy", "increased legroom", flight));
                    seats.Add(new Seat("K2", "economy", "normal", flight));
                    seats.Add(new Seat("K3", "economy", "normal", flight));
                    seats.Add(new Seat("K4", "economy", "normal", flight));
                    seats.Add(new Seat("K5", "economy", "normal", flight));
                    seats.Add(new Seat("K6", "economy", "normal", flight));
                    seats.Add(new Seat("K7", "economy", "normal", flight));
                    seats.Add(new Seat("K8", "economy", "normal", flight));
                    seats.Add(new Seat("K9", "economy", "normal", flight));
                    seats.Add(new Seat("Ka", "economy", "normal", flight));
                    seats.Add(new Seat("Kb", "economy", "normal", flight));
                    seats.Add(new Seat("Kc", "economy", "normal", flight));
                    seats.Add(new Seat("Kd", "economy", "normal", flight));
                    seats.Add(new Seat("Ke", "economy", "normal", flight));
                    seats.Add(new Seat("Kf", "economy", "normal", flight));
                    seats.Add(new Seat("Kg", "economy", "normal", flight));
                    seats.Add(new Seat("Kh", "economy", "limited recline", flight));

                    seats.Add(new Seat("L0", "economy", "increased legroom, limited recline", flight));
                    seats.Add(new Seat("L1", "economy", "increased legroom", flight));
                    seats.Add(new Seat("L2", "economy", "normal", flight));
                    seats.Add(new Seat("L3", "economy", "normal", flight));
                    seats.Add(new Seat("L4", "economy", "normal", flight));
                    seats.Add(new Seat("L5", "economy", "normal", flight));
                    seats.Add(new Seat("L6", "economy", "normal", flight));
                    seats.Add(new Seat("L7", "economy", "normal", flight));
                    seats.Add(new Seat("L8", "economy", "normal", flight));
                    seats.Add(new Seat("L9", "economy", "normal", flight));
                    seats.Add(new Seat("La", "economy", "normal", flight));
                    seats.Add(new Seat("Lb", "economy", "normal", flight));
                    seats.Add(new Seat("Lc", "economy", "normal", flight));
                    seats.Add(new Seat("Ld", "economy", "normal", flight));
                    seats.Add(new Seat("Le", "economy", "normal", flight));
                    seats.Add(new Seat("Lf", "economy", "normal", flight));
                    seats.Add(new Seat("Lg", "economy", "normal", flight));
                    seats.Add(new Seat("Lh", "economy", "limited recline", flight));
                    break;

                case "Airbus 330": // ------------------------------------------------------- Airbus 330
                    seats.Add(new Seat("A0", "first", "normal", flight));
                    seats.Add(new Seat("A1", "first", "normal", flight));

                    seats.Add(new Seat("B0", "first", "normal", flight));
                    seats.Add(new Seat("B1", "first", "normal", flight));

                    seats.Add(new Seat("C0", "first", "normal", flight));
                    seats.Add(new Seat("C1", "first", "normal", flight));

                    seats.Add(new Seat("D0", "first", "normal", flight));
                    seats.Add(new Seat("D1", "first", "normal", flight));

                    seats.Add(new Seat("E0", "first", "normal", flight));
                    seats.Add(new Seat("E1", "first", "normal", flight));

                    seats.Add(new Seat("F0", "first", "normal", flight));
                    seats.Add(new Seat("F1", "first", "normal", flight));

                    seats.Add(new Seat("G0", "business", "normal", flight));
                    seats.Add(new Seat("G1", "business", "normal", flight));
                    seats.Add(new Seat("G2", "business", "normal", flight));
                    seats.Add(new Seat("G3", "business", "missing window", flight));

                    seats.Add(new Seat("H0", "business", "normal", flight));
                    seats.Add(new Seat("H1", "business", "normal", flight));
                    seats.Add(new Seat("H2", "business", "normal", flight));
                    seats.Add(new Seat("H3", "business", "normal", flight));

                    seats.Add(new Seat("I0", "business", "normal", flight));
                    seats.Add(new Seat("I1", "business", "normal", flight));
                    seats.Add(new Seat("I2", "business", "normal", flight));
                    seats.Add(new Seat("I3", "business", "normal", flight));

                    seats.Add(new Seat("J0", "business", "normal", flight));
                    seats.Add(new Seat("J1", "business", "normal", flight));
                    seats.Add(new Seat("J2", "business", "normal", flight));
                    seats.Add(new Seat("J3", "business", "normal", flight));
                    seats.Add(new Seat("J4", "business", "normal", flight));
                    seats.Add(new Seat("J5", "business", "normal", flight));

                    seats.Add(new Seat("K0", "business", "normal", flight));
                    seats.Add(new Seat("K1", "business", "normal", flight));
                    seats.Add(new Seat("K2", "business", "normal", flight));
                    seats.Add(new Seat("K3", "business", "normal", flight));
                    seats.Add(new Seat("K4", "business", "normal", flight));
                    seats.Add(new Seat("K5", "business", "normal", flight));

                    seats.Add(new Seat("L0", "business", "normal", flight));
                    seats.Add(new Seat("L1", "business", "normal", flight));
                    seats.Add(new Seat("L2", "business", "normal", flight));
                    seats.Add(new Seat("L3", "business", "normal", flight));
                    seats.Add(new Seat("L4", "business", "normal", flight));
                    seats.Add(new Seat("L5", "business", "normal", flight));

                    seats.Add(new Seat("M0", "business", "normal", flight));
                    seats.Add(new Seat("M1", "business", "normal", flight));
                    seats.Add(new Seat("M2", "business", "normal", flight));
                    seats.Add(new Seat("M3", "business", "normal", flight));

                    seats.Add(new Seat("N0", "business", "normal", flight));
                    seats.Add(new Seat("N1", "business", "normal", flight));
                    seats.Add(new Seat("N2", "business", "normal", flight));
                    seats.Add(new Seat("N3", "business", "normal", flight));

                    seats.Add(new Seat("O0", "business", "normal", flight));
                    seats.Add(new Seat("O1", "business", "normal", flight));
                    seats.Add(new Seat("O2", "business", "normal", flight));
                    seats.Add(new Seat("O3", "business", "missing window", flight));

                    seats.Add(new Seat("P0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("P1", "economy", "normal", flight));
                    seats.Add(new Seat("P2", "economy", "normal", flight));
                    seats.Add(new Seat("P3", "economy", "normal", flight));
                    seats.Add(new Seat("P4", "economy", "normal", flight));
                    seats.Add(new Seat("P5", "economy", "normal", flight));
                    seats.Add(new Seat("P6", "economy", "normal", flight));
                    seats.Add(new Seat("P7", "economy", "normal", flight));
                    seats.Add(new Seat("P8", "economy", "normal", flight));
                    seats.Add(new Seat("P9", "economy", "normal", flight));
                    seats.Add(new Seat("Pa", "economy", "normal", flight));
                    seats.Add(new Seat("Pb", "economy", "normal", flight));
                    seats.Add(new Seat("Pc", "economy", "normal", flight));
                    seats.Add(new Seat("Pd", "economy", "normal", flight));
                    seats.Add(new Seat("Pe", "economy", "normal", flight));
                    seats.Add(new Seat("Pf", "economy", "normal", flight));
                    seats.Add(new Seat("Pg", "economy", "normal", flight));
                    seats.Add(new Seat("Ph", "economy", "normal", flight));
                    seats.Add(new Seat("Pi", "economy", "normal", flight));

                    seats.Add(new Seat("Q0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("Q1", "economy", "normal", flight));
                    seats.Add(new Seat("Q2", "economy", "normal", flight));
                    seats.Add(new Seat("Q3", "economy", "normal", flight));
                    seats.Add(new Seat("Q4", "economy", "normal", flight));
                    seats.Add(new Seat("Q5", "economy", "normal", flight));
                    seats.Add(new Seat("Q6", "economy", "normal", flight));
                    seats.Add(new Seat("Q7", "economy", "normal", flight));
                    seats.Add(new Seat("Q8", "economy", "normal", flight));
                    seats.Add(new Seat("Q9", "economy", "normal", flight));
                    seats.Add(new Seat("Qa", "economy", "normal", flight));
                    seats.Add(new Seat("Qb", "economy", "normal", flight));
                    seats.Add(new Seat("Qc", "economy", "normal", flight));
                    seats.Add(new Seat("Qd", "economy", "normal", flight));
                    seats.Add(new Seat("Qe", "economy", "normal", flight));
                    seats.Add(new Seat("Qf", "economy", "normal", flight));
                    seats.Add(new Seat("Qg", "economy", "normal", flight));
                    seats.Add(new Seat("Qh", "economy", "normal", flight));
                    seats.Add(new Seat("Qi", "economy", "normal", flight));

                    seats.Add(new Seat("R0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("R1", "economy", "normal", flight));
                    seats.Add(new Seat("R2", "economy", "normal", flight));
                    seats.Add(new Seat("R3", "economy", "normal", flight));
                    seats.Add(new Seat("R4", "economy", "normal", flight));
                    seats.Add(new Seat("R5", "economy", "normal", flight));
                    seats.Add(new Seat("R6", "economy", "normal", flight));
                    seats.Add(new Seat("R7", "economy", "normal", flight));
                    seats.Add(new Seat("R8", "economy", "normal", flight));
                    seats.Add(new Seat("R9", "economy", "normal", flight));
                    seats.Add(new Seat("Ra", "economy", "normal", flight));
                    seats.Add(new Seat("Rb", "economy", "normal", flight));
                    seats.Add(new Seat("Rc", "economy", "normal", flight));
                    seats.Add(new Seat("Rd", "economy", "normal", flight));
                    seats.Add(new Seat("Re", "economy", "normal", flight));
                    seats.Add(new Seat("Rf", "economy", "normal", flight));
                    seats.Add(new Seat("Rg", "economy", "normal", flight));
                    seats.Add(new Seat("Rh", "economy", "normal", flight));
                    seats.Add(new Seat("Ri", "economy", "normal", flight));

                    seats.Add(new Seat("S0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("S1", "economy", "normal", flight));
                    seats.Add(new Seat("S2", "economy", "normal", flight));
                    seats.Add(new Seat("S3", "economy", "normal", flight));
                    seats.Add(new Seat("S4", "economy", "normal", flight));
                    seats.Add(new Seat("S5", "economy", "normal", flight));
                    seats.Add(new Seat("S6", "economy", "normal", flight));
                    seats.Add(new Seat("S7", "economy", "normal", flight));
                    seats.Add(new Seat("S8", "economy", "normal", flight));
                    seats.Add(new Seat("S9", "economy", "normal", flight));
                    seats.Add(new Seat("Sa", "economy", "normal", flight));
                    seats.Add(new Seat("Sb", "economy", "normal", flight));
                    seats.Add(new Seat("Sc", "economy", "normal", flight));
                    seats.Add(new Seat("Sd", "economy", "normal", flight));
                    seats.Add(new Seat("Se", "economy", "normal", flight));
                    seats.Add(new Seat("Sf", "economy", "normal", flight));
                    seats.Add(new Seat("Sg", "economy", "normal", flight));
                    seats.Add(new Seat("Sh", "economy", "normal", flight));
                    seats.Add(new Seat("Si", "economy", "normal", flight));
                    seats.Add(new Seat("Sj", "economy", "normal", flight));

                    seats.Add(new Seat("T0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("T1", "economy", "normal", flight));
                    seats.Add(new Seat("T2", "economy", "normal", flight));
                    seats.Add(new Seat("T3", "economy", "normal", flight));
                    seats.Add(new Seat("T4", "economy", "normal", flight));
                    seats.Add(new Seat("T5", "economy", "normal", flight));
                    seats.Add(new Seat("T6", "economy", "normal", flight));
                    seats.Add(new Seat("T7", "economy", "normal", flight));
                    seats.Add(new Seat("T8", "economy", "normal", flight));
                    seats.Add(new Seat("T9", "economy", "normal", flight));
                    seats.Add(new Seat("Ta", "economy", "normal", flight));
                    seats.Add(new Seat("Tb", "economy", "normal", flight));
                    seats.Add(new Seat("Tc", "economy", "normal", flight));
                    seats.Add(new Seat("Td", "economy", "normal", flight));
                    seats.Add(new Seat("Te", "economy", "normal", flight));
                    seats.Add(new Seat("Tf", "economy", "normal", flight));
                    seats.Add(new Seat("Tg", "economy", "normal", flight));
                    seats.Add(new Seat("Th", "economy", "normal", flight));
                    seats.Add(new Seat("Ti", "economy", "normal", flight));
                    seats.Add(new Seat("Tj", "economy", "normal", flight));

                    seats.Add(new Seat("U0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("U1", "economy", "normal", flight));
                    seats.Add(new Seat("U2", "economy", "normal", flight));
                    seats.Add(new Seat("U3", "economy", "normal", flight));
                    seats.Add(new Seat("U4", "economy", "normal", flight));
                    seats.Add(new Seat("U5", "economy", "normal", flight));
                    seats.Add(new Seat("U6", "economy", "normal", flight));
                    seats.Add(new Seat("U7", "economy", "normal", flight));
                    seats.Add(new Seat("U8", "economy", "normal", flight));
                    seats.Add(new Seat("U9", "economy", "normal", flight));
                    seats.Add(new Seat("Ua", "economy", "normal", flight));
                    seats.Add(new Seat("Ub", "economy", "normal", flight));
                    seats.Add(new Seat("Uc", "economy", "normal", flight));
                    seats.Add(new Seat("Ud", "economy", "normal", flight));
                    seats.Add(new Seat("Ue", "economy", "normal", flight));
                    seats.Add(new Seat("Uf", "economy", "normal", flight));
                    seats.Add(new Seat("Ug", "economy", "normal", flight));
                    seats.Add(new Seat("Uh", "economy", "normal", flight));
                    seats.Add(new Seat("Ui", "economy", "normal", flight));
                    seats.Add(new Seat("Uj", "economy", "normal", flight));

                    seats.Add(new Seat("V0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("V1", "economy", "normal", flight));
                    seats.Add(new Seat("V2", "economy", "normal", flight));
                    seats.Add(new Seat("V3", "economy", "normal", flight));
                    seats.Add(new Seat("V4", "economy", "normal", flight));
                    seats.Add(new Seat("V5", "economy", "normal", flight));
                    seats.Add(new Seat("V6", "economy", "normal", flight));
                    seats.Add(new Seat("V7", "economy", "normal", flight));
                    seats.Add(new Seat("V8", "economy", "normal", flight));
                    seats.Add(new Seat("V9", "economy", "normal", flight));
                    seats.Add(new Seat("Va", "economy", "normal", flight));
                    seats.Add(new Seat("Vb", "economy", "normal", flight));
                    seats.Add(new Seat("Vc", "economy", "normal", flight));
                    seats.Add(new Seat("Vd", "economy", "normal", flight));
                    seats.Add(new Seat("Ve", "economy", "normal", flight));
                    seats.Add(new Seat("Vf", "economy", "normal", flight));
                    seats.Add(new Seat("Vg", "economy", "normal", flight));
                    seats.Add(new Seat("Vh", "economy", "normal", flight));
                    seats.Add(new Seat("Vi", "economy", "normal", flight));

                    seats.Add(new Seat("W0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("W1", "economy", "normal", flight));
                    seats.Add(new Seat("W2", "economy", "normal", flight));
                    seats.Add(new Seat("W3", "economy", "normal", flight));
                    seats.Add(new Seat("W4", "economy", "normal", flight));
                    seats.Add(new Seat("W5", "economy", "normal", flight));
                    seats.Add(new Seat("W6", "economy", "normal", flight));
                    seats.Add(new Seat("W7", "economy", "normal", flight));
                    seats.Add(new Seat("W8", "economy", "normal", flight));
                    seats.Add(new Seat("W9", "economy", "normal", flight));
                    seats.Add(new Seat("Wa", "economy", "normal", flight));
                    seats.Add(new Seat("Wb", "economy", "normal", flight));
                    seats.Add(new Seat("Wc", "economy", "normal", flight));
                    seats.Add(new Seat("Wd", "economy", "normal", flight));
                    seats.Add(new Seat("We", "economy", "normal", flight));
                    seats.Add(new Seat("Wf", "economy", "normal", flight));
                    seats.Add(new Seat("Wg", "economy", "normal", flight));
                    seats.Add(new Seat("Wh", "economy", "normal", flight));
                    seats.Add(new Seat("Wi", "economy", "normal", flight));

                    seats.Add(new Seat("X0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("X1", "economy", "normal", flight));
                    seats.Add(new Seat("X2", "economy", "normal", flight));
                    seats.Add(new Seat("X3", "economy", "normal", flight));
                    seats.Add(new Seat("X4", "economy", "normal", flight));
                    seats.Add(new Seat("X5", "economy", "normal", flight));
                    seats.Add(new Seat("X6", "economy", "normal", flight));
                    seats.Add(new Seat("X7", "economy", "normal", flight));
                    seats.Add(new Seat("X8", "economy", "normal", flight));
                    seats.Add(new Seat("X9", "economy", "normal", flight));
                    seats.Add(new Seat("Xa", "economy", "normal", flight));
                    seats.Add(new Seat("Xb", "economy", "normal", flight));
                    seats.Add(new Seat("Xc", "economy", "normal", flight));
                    seats.Add(new Seat("Xd", "economy", "normal", flight));
                    seats.Add(new Seat("Xe", "economy", "normal", flight));
                    seats.Add(new Seat("Xf", "economy", "normal", flight));
                    seats.Add(new Seat("Xg", "economy", "normal", flight));
                    seats.Add(new Seat("Xh", "economy", "normal", flight));
                    seats.Add(new Seat("Xi", "economy", "normal", flight));

                    seats.Add(new Seat("a0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("a1", "economy", "normal", flight));
                    seats.Add(new Seat("a2", "economy", "normal", flight));
                    seats.Add(new Seat("a3", "economy", "normal", flight));
                    seats.Add(new Seat("a4", "economy", "normal", flight));
                    seats.Add(new Seat("a5", "economy", "normal", flight));
                    seats.Add(new Seat("a6", "economy", "normal", flight));
                    seats.Add(new Seat("a7", "economy", "normal", flight));

                    seats.Add(new Seat("b0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("b1", "economy", "normal", flight));
                    seats.Add(new Seat("b2", "economy", "normal", flight));
                    seats.Add(new Seat("b3", "economy", "normal", flight));
                    seats.Add(new Seat("b4", "economy", "normal", flight));
                    seats.Add(new Seat("b5", "economy", "normal", flight));
                    seats.Add(new Seat("b6", "economy", "normal", flight));
                    seats.Add(new Seat("b7", "economy", "normal", flight));

                    seats.Add(new Seat("c0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("c1", "economy", "normal", flight));
                    seats.Add(new Seat("c2", "economy", "normal", flight));
                    seats.Add(new Seat("c3", "economy", "normal", flight));
                    seats.Add(new Seat("c4", "economy", "normal", flight));
                    seats.Add(new Seat("c5", "economy", "normal", flight));
                    seats.Add(new Seat("c6", "economy", "normal", flight));
                    seats.Add(new Seat("c7", "economy", "normal", flight));

                    seats.Add(new Seat("d0", "economy", "limited legroom", flight));
                    seats.Add(new Seat("d1", "economy", "normal", flight));
                    seats.Add(new Seat("d2", "economy", "normal", flight));
                    seats.Add(new Seat("d3", "economy", "normal", flight));
                    seats.Add(new Seat("d4", "economy", "normal", flight));
                    seats.Add(new Seat("d5", "economy", "normal", flight));
                    seats.Add(new Seat("d6", "economy", "normal", flight));
                    seats.Add(new Seat("d7", "economy", "normal", flight));
                    seats.Add(new Seat("d8", "economy", "normal", flight));
                    seats.Add(new Seat("d9", "economy", "normal", flight));
                    seats.Add(new Seat("da", "economy", "normal", flight));
                    seats.Add(new Seat("db", "economy", "normal", flight));
                    seats.Add(new Seat("dc", "economy", "normal", flight));
                    seats.Add(new Seat("dd", "economy", "normal", flight));
                    seats.Add(new Seat("de", "economy", "normal", flight));

                    seats.Add(new Seat("e0", "economy", "limited legroom", flight));
                    seats.Add(new Seat("e1", "economy", "normal", flight));
                    seats.Add(new Seat("e2", "economy", "normal", flight));
                    seats.Add(new Seat("e3", "economy", "normal", flight));
                    seats.Add(new Seat("e4", "economy", "normal", flight));
                    seats.Add(new Seat("e5", "economy", "normal", flight));
                    seats.Add(new Seat("e6", "economy", "normal", flight));
                    seats.Add(new Seat("e7", "economy", "normal", flight));
                    seats.Add(new Seat("e8", "economy", "normal", flight));
                    seats.Add(new Seat("e9", "economy", "normal", flight));
                    seats.Add(new Seat("ea", "economy", "normal", flight));
                    seats.Add(new Seat("eb", "economy", "normal", flight));
                    seats.Add(new Seat("ec", "economy", "normal", flight));
                    seats.Add(new Seat("ed", "economy", "normal", flight));
                    seats.Add(new Seat("ee", "economy", "normal", flight));

                    seats.Add(new Seat("f0", "economy", "limited legroom", flight));
                    seats.Add(new Seat("f1", "economy", "normal", flight));
                    seats.Add(new Seat("f2", "economy", "normal", flight));
                    seats.Add(new Seat("f3", "economy", "normal", flight));
                    seats.Add(new Seat("f4", "economy", "normal", flight));
                    seats.Add(new Seat("f5", "economy", "normal", flight));
                    seats.Add(new Seat("f6", "economy", "normal", flight));
                    seats.Add(new Seat("f7", "economy", "normal", flight));
                    seats.Add(new Seat("f8", "economy", "normal", flight));
                    seats.Add(new Seat("f9", "economy", "normal", flight));
                    seats.Add(new Seat("fa", "economy", "normal", flight));
                    seats.Add(new Seat("fb", "economy", "normal", flight));
                    seats.Add(new Seat("fc", "economy", "normal", flight));
                    seats.Add(new Seat("fd", "economy", "normal", flight));
                    seats.Add(new Seat("fe", "economy", "normal", flight));

                    seats.Add(new Seat("g0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("g1", "economy", "normal", flight));
                    seats.Add(new Seat("g2", "economy", "normal", flight));
                    seats.Add(new Seat("g3", "economy", "normal", flight));
                    seats.Add(new Seat("g4", "economy", "normal", flight));
                    seats.Add(new Seat("g5", "economy", "normal", flight));
                    seats.Add(new Seat("g6", "economy", "normal", flight));
                    seats.Add(new Seat("g7", "economy", "normal", flight));

                    seats.Add(new Seat("h0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("h1", "economy", "normal", flight));
                    seats.Add(new Seat("h2", "economy", "normal", flight));
                    seats.Add(new Seat("h3", "economy", "normal", flight));
                    seats.Add(new Seat("h4", "economy", "normal", flight));
                    seats.Add(new Seat("h5", "economy", "normal", flight));
                    seats.Add(new Seat("h6", "economy", "normal", flight));
                    seats.Add(new Seat("h7", "economy", "normal", flight));

                    seats.Add(new Seat("i0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("i1", "economy", "normal", flight));
                    seats.Add(new Seat("i2", "economy", "normal", flight));
                    seats.Add(new Seat("i3", "economy", "normal", flight));
                    seats.Add(new Seat("i4", "economy", "normal", flight));
                    seats.Add(new Seat("i5", "economy", "normal", flight));
                    seats.Add(new Seat("i6", "economy", "normal", flight));
                    seats.Add(new Seat("i7", "economy", "normal", flight));

                    seats.Add(new Seat("j0", "economy", "normal", flight));
                    seats.Add(new Seat("j1", "economy", "normal", flight));
                    seats.Add(new Seat("j2", "economy", "normal", flight));
                    seats.Add(new Seat("j3", "economy", "normal", flight));
                    seats.Add(new Seat("j4", "economy", "normal", flight));
                    seats.Add(new Seat("j5", "economy", "limited recline", flight));

                    seats.Add(new Seat("k0", "economy", "normal", flight));
                    seats.Add(new Seat("k1", "economy", "normal", flight));
                    seats.Add(new Seat("k2", "economy", "normal", flight));
                    seats.Add(new Seat("k3", "economy", "normal", flight));
                    seats.Add(new Seat("k4", "economy", "normal", flight));
                    seats.Add(new Seat("k5", "economy", "limited recline", flight));

                    seats.Add(new Seat("l0", "economy", "normal", flight));
                    seats.Add(new Seat("l1", "economy", "normal", flight));
                    seats.Add(new Seat("l2", "economy", "normal", flight));
                    seats.Add(new Seat("l3", "economy", "normal", flight));
                    seats.Add(new Seat("l4", "economy", "normal", flight));
                    seats.Add(new Seat("l5", "economy", "limited recline", flight));

                    seats.Add(new Seat("m0", "economy", "normal", flight));
                    seats.Add(new Seat("m1", "economy", "normal", flight));
                    seats.Add(new Seat("m2", "economy", "normal", flight));
                    seats.Add(new Seat("m3", "economy", "normal", flight));
                    seats.Add(new Seat("m4", "economy", "normal", flight));
                    seats.Add(new Seat("m5", "economy", "limited recline", flight));
                    break;
                case "Boeing 787": // ------------------------------------------------------- Boeing 787
                    seats.Add(new Seat("A0", "first", "normal", flight));
                    seats.Add(new Seat("A1", "first", "normal", flight));
                    seats.Add(new Seat("A2", "first", "normal", flight));
                    seats.Add(new Seat("A3", "first", "normal", flight));
                    seats.Add(new Seat("A4", "first", "normal", flight));
                    seats.Add(new Seat("A5", "first", "normal", flight));

                    seats.Add(new Seat("B0", "first", "normal", flight));
                    seats.Add(new Seat("B1", "first", "normal", flight));
                    seats.Add(new Seat("B2", "first", "normal", flight));
                    seats.Add(new Seat("B3", "first", "normal", flight));
                    seats.Add(new Seat("B4", "first", "normal", flight));
                    seats.Add(new Seat("B5", "first", "normal", flight));

                    seats.Add(new Seat("C0", "first", "normal", flight));
                    seats.Add(new Seat("C1", "first", "normal", flight));
                    seats.Add(new Seat("C2", "first", "normal", flight));
                    seats.Add(new Seat("C3", "first", "normal", flight));
                    seats.Add(new Seat("C4", "first", "normal", flight));
                    seats.Add(new Seat("C5", "first", "normal", flight));

                    seats.Add(new Seat("D0", "first", "normal", flight));
                    seats.Add(new Seat("D1", "first", "normal", flight));
                    seats.Add(new Seat("D2", "first", "normal", flight));
                    seats.Add(new Seat("D3", "first", "normal", flight));
                    seats.Add(new Seat("D4", "first", "normal", flight));
                    seats.Add(new Seat("D5", "first", "normal", flight));

                    seats.Add(new Seat("E0", "first", "normal", flight));
                    seats.Add(new Seat("E1", "first", "normal", flight));
                    seats.Add(new Seat("E2", "first", "normal", flight));
                    seats.Add(new Seat("E3", "first", "normal", flight));
                    seats.Add(new Seat("E4", "first", "normal", flight));
                    seats.Add(new Seat("E5", "first", "normal", flight));

                    seats.Add(new Seat("F0", "first", "normal", flight));
                    seats.Add(new Seat("F1", "first", "normal", flight));
                    seats.Add(new Seat("F2", "first", "normal", flight));
                    seats.Add(new Seat("F3", "first", "normal", flight));
                    seats.Add(new Seat("F4", "first", "normal", flight));
                    seats.Add(new Seat("F5", "first", "normal", flight));

                    seats.Add(new Seat("G0", "business", "limited legroom", flight));
                    seats.Add(new Seat("G1", "business", "normal", flight));
                    seats.Add(new Seat("G2", "business", "normal", flight));
                    seats.Add(new Seat("G3", "business", "normal", flight));
                    seats.Add(new Seat("G4", "business", "normal", flight));
                    seats.Add(new Seat("G5", "economy", "normal", flight));
                    seats.Add(new Seat("G6", "economy", "normal", flight));
                    seats.Add(new Seat("G7", "economy", "normal", flight));
                    seats.Add(new Seat("G8", "economy", "normal", flight));
                    seats.Add(new Seat("G9", "economy", "limited recline", flight));

                    seats.Add(new Seat("H0", "business", "limited legroom", flight));
                    seats.Add(new Seat("H1", "business", "normal", flight));
                    seats.Add(new Seat("H2", "business", "normal", flight));
                    seats.Add(new Seat("H3", "business", "normal", flight));
                    seats.Add(new Seat("H4", "business", "normal", flight));
                    seats.Add(new Seat("H5", "economy", "normal", flight));
                    seats.Add(new Seat("H6", "economy", "normal", flight));
                    seats.Add(new Seat("H7", "economy", "normal", flight));
                    seats.Add(new Seat("H8", "economy", "normal", flight));
                    seats.Add(new Seat("H9", "economy", "limited recline", flight));

                    seats.Add(new Seat("I0", "business", "limited legroom", flight));
                    seats.Add(new Seat("I1", "business", "normal", flight));
                    seats.Add(new Seat("I2", "business", "normal", flight));
                    seats.Add(new Seat("I3", "business", "normal", flight));
                    seats.Add(new Seat("I4", "business", "normal", flight));
                    seats.Add(new Seat("I5", "economy", "normal", flight));
                    seats.Add(new Seat("I6", "economy", "normal", flight));
                    seats.Add(new Seat("I7", "economy", "normal", flight));
                    seats.Add(new Seat("I8", "economy", "normal", flight));
                    seats.Add(new Seat("I9", "economy", "limited recline", flight));

                    seats.Add(new Seat("J0", "business", "limited legroom", flight));
                    seats.Add(new Seat("J1", "business", "normal", flight));
                    seats.Add(new Seat("J2", "business", "normal", flight));
                    seats.Add(new Seat("J3", "business", "normal", flight));
                    seats.Add(new Seat("J4", "business", "normal", flight));
                    seats.Add(new Seat("J5", "economy", "normal", flight));
                    seats.Add(new Seat("J6", "economy", "normal", flight));
                    seats.Add(new Seat("J7", "economy", "normal", flight));
                    seats.Add(new Seat("J8", "economy", "limited recline", flight));

                    seats.Add(new Seat("K0", "business", "limited legroom", flight));
                    seats.Add(new Seat("K1", "business", "normal", flight));
                    seats.Add(new Seat("K2", "business", "normal", flight));
                    seats.Add(new Seat("K3", "business", "normal", flight));
                    seats.Add(new Seat("K4", "business", "normal", flight));
                    seats.Add(new Seat("K5", "economy", "normal", flight));
                    seats.Add(new Seat("K6", "economy", "normal", flight));
                    seats.Add(new Seat("K7", "economy", "normal", flight));
                    seats.Add(new Seat("K8", "economy", "limited recline", flight));

                    seats.Add(new Seat("L0", "business", "limited legroom", flight));
                    seats.Add(new Seat("L1", "business", "normal", flight));
                    seats.Add(new Seat("L2", "business", "normal", flight));
                    seats.Add(new Seat("L3", "business", "normal", flight));
                    seats.Add(new Seat("L4", "business", "normal", flight));
                    seats.Add(new Seat("L5", "economy", "normal", flight));
                    seats.Add(new Seat("L6", "economy", "normal", flight));
                    seats.Add(new Seat("L7", "economy", "normal", flight));
                    seats.Add(new Seat("L8", "economy", "limited recline", flight));

                    seats.Add(new Seat("M0", "business", "limited legroom", flight));
                    seats.Add(new Seat("M1", "business", "normal", flight));
                    seats.Add(new Seat("M2", "business", "normal", flight));
                    seats.Add(new Seat("M3", "business", "normal", flight));
                    seats.Add(new Seat("M4", "business", "normal", flight));
                    seats.Add(new Seat("M5", "economy", "normal", flight));
                    seats.Add(new Seat("M6", "economy", "normal", flight));
                    seats.Add(new Seat("M7", "economy", "normal", flight));
                    seats.Add(new Seat("M8", "economy", "normal", flight));
                    seats.Add(new Seat("M9", "economy", "limited recline", flight));

                    seats.Add(new Seat("N0", "business", "limited legroom", flight));
                    seats.Add(new Seat("N1", "business", "normal", flight));
                    seats.Add(new Seat("N2", "business", "normal", flight));
                    seats.Add(new Seat("N3", "business", "normal", flight));
                    seats.Add(new Seat("N4", "business", "normal", flight));
                    seats.Add(new Seat("N5", "economy", "normal", flight));
                    seats.Add(new Seat("N6", "economy", "normal", flight));
                    seats.Add(new Seat("N7", "economy", "normal", flight));
                    seats.Add(new Seat("N8", "economy", "normal", flight));
                    seats.Add(new Seat("N9", "economy", "limited recline", flight));

                    seats.Add(new Seat("O0", "business", "limited legroom", flight));
                    seats.Add(new Seat("O1", "business", "normal", flight));
                    seats.Add(new Seat("O2", "business", "normal", flight));
                    seats.Add(new Seat("O3", "business", "normal", flight));
                    seats.Add(new Seat("O4", "business", "normal", flight));
                    seats.Add(new Seat("O5", "economy", "normal", flight));
                    seats.Add(new Seat("O6", "economy", "normal", flight));
                    seats.Add(new Seat("O7", "economy", "normal", flight));
                    seats.Add(new Seat("O8", "economy", "normal", flight));
                    seats.Add(new Seat("O9", "economy", "limited recline", flight));

                    seats.Add(new Seat("P0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("P1", "economy", "normal", flight));
                    seats.Add(new Seat("P2", "economy", "normal", flight));
                    seats.Add(new Seat("P3", "economy", "normal", flight));
                    seats.Add(new Seat("P4", "economy", "normal", flight));
                    seats.Add(new Seat("P5", "economy", "normal", flight));
                    seats.Add(new Seat("P6", "economy", "normal", flight));
                    seats.Add(new Seat("P7", "economy", "normal", flight));
                    seats.Add(new Seat("P8", "economy", "normal", flight));
                    seats.Add(new Seat("P9", "economy", "limited recline", flight));

                    seats.Add(new Seat("Q0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("Q1", "economy", "normal", flight));
                    seats.Add(new Seat("Q2", "economy", "normal", flight));
                    seats.Add(new Seat("Q3", "economy", "normal", flight));
                    seats.Add(new Seat("Q4", "economy", "normal", flight));
                    seats.Add(new Seat("Q5", "economy", "normal", flight));
                    seats.Add(new Seat("Q6", "economy", "normal", flight));
                    seats.Add(new Seat("Q7", "economy", "normal", flight));
                    seats.Add(new Seat("Q8", "economy", "normal", flight));
                    seats.Add(new Seat("Q9", "economy", "limited recline", flight));

                    seats.Add(new Seat("R0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("R1", "economy", "normal", flight));
                    seats.Add(new Seat("R2", "economy", "normal", flight));
                    seats.Add(new Seat("R3", "economy", "normal", flight));
                    seats.Add(new Seat("R4", "economy", "normal", flight));
                    seats.Add(new Seat("R5", "economy", "normal", flight));
                    seats.Add(new Seat("R6", "economy", "normal", flight));
                    seats.Add(new Seat("R7", "economy", "normal", flight));
                    seats.Add(new Seat("R8", "economy", "normal", flight));
                    seats.Add(new Seat("R9", "economy", "limited recline", flight));

                    seats.Add(new Seat("S0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("S1", "economy", "normal", flight));
                    seats.Add(new Seat("S2", "economy", "normal", flight));
                    seats.Add(new Seat("S3", "economy", "normal", flight));
                    seats.Add(new Seat("S4", "economy", "normal", flight));
                    seats.Add(new Seat("S5", "economy", "normal", flight));
                    seats.Add(new Seat("S6", "economy", "normal", flight));
                    seats.Add(new Seat("S7", "economy", "normal", flight));
                    seats.Add(new Seat("S8", "economy", "normal", flight));
                    seats.Add(new Seat("S9", "economy", "normal", flight));
                    seats.Add(new Seat("Sa", "economy", "normal", flight));
                    seats.Add(new Seat("Sb", "economy", "normal", flight));

                    seats.Add(new Seat("T0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("T1", "economy", "normal", flight));
                    seats.Add(new Seat("T2", "economy", "normal", flight));
                    seats.Add(new Seat("T3", "economy", "normal", flight));
                    seats.Add(new Seat("T4", "economy", "normal", flight));
                    seats.Add(new Seat("T5", "economy", "normal", flight));
                    seats.Add(new Seat("T6", "economy", "normal", flight));
                    seats.Add(new Seat("T7", "economy", "normal", flight));
                    seats.Add(new Seat("T8", "economy", "normal", flight));
                    seats.Add(new Seat("T9", "economy", "normal", flight));
                    seats.Add(new Seat("Ta", "economy", "normal", flight));
                    seats.Add(new Seat("Tb", "economy", "normal", flight));

                    seats.Add(new Seat("U0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("U1", "economy", "normal", flight));
                    seats.Add(new Seat("U2", "economy", "normal", flight));
                    seats.Add(new Seat("U3", "economy", "normal", flight));
                    seats.Add(new Seat("U4", "economy", "normal", flight));
                    seats.Add(new Seat("U5", "economy", "normal", flight));
                    seats.Add(new Seat("U6", "economy", "normal", flight));
                    seats.Add(new Seat("U7", "economy", "normal", flight));
                    seats.Add(new Seat("U8", "economy", "normal", flight));
                    seats.Add(new Seat("U9", "economy", "normal", flight));
                    seats.Add(new Seat("Ua", "economy", "normal", flight));
                    seats.Add(new Seat("Ub", "economy", "normal", flight));

                    seats.Add(new Seat("V0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("V1", "economy", "normal", flight));
                    seats.Add(new Seat("V2", "economy", "normal", flight));
                    seats.Add(new Seat("V3", "economy", "normal", flight));
                    seats.Add(new Seat("V4", "economy", "normal", flight));
                    seats.Add(new Seat("V5", "economy", "normal", flight));
                    seats.Add(new Seat("V6", "economy", "normal", flight));
                    seats.Add(new Seat("V7", "economy", "normal", flight));
                    seats.Add(new Seat("V8", "economy", "normal", flight));
                    seats.Add(new Seat("V9", "economy", "limited recline", flight));

                    seats.Add(new Seat("W0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("W1", "economy", "normal", flight));
                    seats.Add(new Seat("W2", "economy", "normal", flight));
                    seats.Add(new Seat("W3", "economy", "normal", flight));
                    seats.Add(new Seat("W4", "economy", "normal", flight));
                    seats.Add(new Seat("W5", "economy", "normal", flight));
                    seats.Add(new Seat("W6", "economy", "normal", flight));
                    seats.Add(new Seat("W7", "economy", "normal", flight));
                    seats.Add(new Seat("W8", "economy", "normal", flight));
                    seats.Add(new Seat("W9", "economy", "limited recline", flight));

                    seats.Add(new Seat("X0", "economy", "increased legroom", flight));
                    seats.Add(new Seat("X1", "economy", "normal", flight));
                    seats.Add(new Seat("X2", "economy", "normal", flight));
                    seats.Add(new Seat("X3", "economy", "normal", flight));
                    seats.Add(new Seat("X4", "economy", "normal", flight));
                    seats.Add(new Seat("X5", "economy", "normal", flight));
                    seats.Add(new Seat("X6", "economy", "normal", flight));
                    seats.Add(new Seat("X7", "economy", "normal", flight));
                    seats.Add(new Seat("X8", "economy", "normal", flight));
                    seats.Add(new Seat("X9", "economy", "limited recline", flight));
                    break;
            }
            return seats;
        }
    }
}
