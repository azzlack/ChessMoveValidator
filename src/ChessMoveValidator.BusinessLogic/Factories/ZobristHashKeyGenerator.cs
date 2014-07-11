namespace ChessMoveValidator.BusinessLogic.Factories
{
    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Factories;
    using ChessMoveValidator.Core.Interfaces.Models;
    using ChessMoveValidator.Core.Models;
    using ChessMoveValidator.Core.Models.Pieces;

    /// <summary>
    /// Class for generating Zobrist hash keys.
    /// </summary>
    public class ZobristHashKeyGenerator : IZobristHashKeyGenerator
    {
        /// <summary>
        /// The Zobrist key array.
        /// </summary>
        /// <remarks>781 unsigned longs generated using the <a href="http://en.wikipedia.org/wiki/Mersenne_twister">Mersenne Twister</a> library from <a href="http://archive.msdn.microsoft.com/MersenneTwister/">NPack</a>.</remarks>
        private readonly ulong[] keys = new[]
                                   {
                                       0x689E4579689E4579UL, 0x7FE13A407FE13A40UL, 0x41534AC441534AC4UL,
                                       0x10D6120410D61204UL, 0x48885DC048885DCUL, 0x7F093DDF7F093DDFUL,
                                       0x5017390850173908UL, 0x803034B0803034BUL, 0x3492297A3492297AUL,
                                       0x1140438611404386UL, 0x7D8D393F7D8D393FUL, 0x6B2FB5536B2FB553UL,
                                       0x7B966F967B966F96UL, 0x1C5325B21C5325B2UL, 0x38E353FD38E353FDUL,
                                       0x2B45EBC42B45EBC4UL, 0x5A48A61A5A48A61AUL, 0x43FC959043FC959UL,
                                       0x2F3324B02F3324B0UL, 0x3624056E3624056EUL, 0x4B6A2CA34B6A2CA3UL,
                                       0x27EF1F2327EF1F23UL, 0x737766E0737766E0UL, 0x5AB9AB4D5AB9AB4DUL,
                                       0x3A7D95BA3A7D95BAUL, 0x4544EB4D4544EB4DUL, 0x93F41E8093F41E8UL,
                                       0x1D3C900F1D3C900FUL, 0x1B1108901B110890UL, 0x647DD7DB647DD7DBUL,
                                       0x42E6D7A942E6D7A9UL, 0x142304A8142304A8UL, 0x5F45D1285F45D128UL,
                                       0x1F0228471F022847UL, 0x5B2EFCB75B2EFCB7UL, 0x5B0EDA605B0EDA60UL,
                                       0x543F00E4543F00E4UL, 0x55F7478B55F7478BUL, 0x5C1B50175C1B5017UL,
                                       0x436B7BDD436B7BDDUL, 0x687EE836687EE836UL, 0x3E013E453E013E45UL,
                                       0x30C7C61E30C7C61EUL, 0x7FF07AEB7FF07AEBUL, 0x3CBBFB2B3CBBFB2BUL,
                                       0x497BC1CC497BC1CCUL, 0x253ED820253ED820UL, 0xE5862200E58622UL, 
                                       0x3586BFE03586BFEUL, 0x27BF77C027BF77C0UL, 0x1A3D07601A3D0760UL, 0x9F97F1C09F97F1CUL,
                                       0x6378159F6378159FUL, 0x8257D6008257D6UL, 0x1FE45B721FE45B72UL,
                                       0x3EEDCBD43EEDCBD4UL, 0x21A5D03321A5D033UL, 0x528B42B8528B42B8UL,
                                       0x5EC574905EC5749UL, 0x3F4ADA793F4ADA79UL, 0x647F35C9647F35C9UL,
                                       0x13E8046D13E8046DUL, 0x24D0151F24D0151FUL, 0x2A1FF6EA2A1FF6EAUL,
                                       0x4630368A4630368AUL, 0x5D566B505D566B50UL, 0x289379A4289379A4UL,
                                       0x65EB151365EB1513UL, 0x6FDFB2B36FDFB2B3UL, 0x4EC875B24EC875B2UL,
                                       0x19796FE719796FE7UL, 0x5426EA1E5426EA1EUL, 0x2E95CAA12E95CAA1UL,
                                       0x52CB007D52CB007DUL, 0x64248A4164248A41UL, 0x2697E92A2697E92AUL,
                                       0x4F7B9D6C4F7B9D6CUL, 0x7A0DBA347A0DBA34UL, 0x180A6623180A6623UL,
                                       0x6ECCAB8A6ECCAB8AUL, 0x1FF25AFD1FF25AFDUL, 0x6C3542B96C3542B9UL,
                                       0x16FD05E916FD05E9UL, 0x21B7C85D21B7C85DUL, 0x6E328B706E328B70UL,
                                       0x7F1A2F397F1A2F39UL, 0x28ACD05D28ACD05DUL, 0x5559C7725559C772UL,
                                       0x211395CF211395CFUL, 0x5B66DFB25B66DFB2UL, 0x52CFAB7452CFAB74UL,
                                       0x76E656BF76E656BFUL, 0x199D451F199D451FUL, 0x4FE182304FE1823UL,
                                       0x209C474A209C474AUL, 0x3A85EE8A3A85EE8AUL, 0x2578A02D2578A02DUL,
                                       0x338E7745338E7745UL, 0x3BF6CCD03BF6CCDUL, 0x1FD985551FD98555UL,
                                       0x347FE55E347FE55EUL, 0x3EC827213EC82721UL, 0x1ECA9DAA1ECA9DAAUL,
                                       0x1C32CF7E1C32CF7EUL, 0x20CBA99B20CBA99BUL, 0xE951D140E951D14UL,
                                       0x4714735147147351UL, 0x13A17B1513A17B15UL, 0x62962B5D62962B5DUL,
                                       0x471BB762471BB762UL, 0x325D6A40325D6A4UL, 0x3AE577863AE57786UL,
                                       0x2DC2E9982DC2E998UL, 0x95CFABC095CFABCUL, 0x252DACE0252DACE0UL,
                                       0x3FB875933FB87593UL, 0x522AD778522AD778UL, 0x4885D5244885D524UL,
                                       0x76579CB276579CB2UL, 0x39F113D439F113D4UL, 0x4685B6FA4685B6FAUL,
                                       0x4BBE69244BBE6924UL, 0x7FB3D34A7FB3D34AUL, 0x6B3D6D806B3D6D8UL,
                                       0x2B7391592B739159UL, 0x41364ABD41364ABDUL, 0x6CEE58936CEE5893UL,
                                       0x1D2E47161D2E4716UL, 0x26248A5326248A53UL, 0x50D0B4E850D0B4E8UL,
                                       0x7A0243357A024335UL, 0x448ACB55448ACB55UL, 0x3F3C93E23F3C93E2UL,
                                       0x4AAB243D4AAB243DUL, 0x370D801E370D801EUL, 0x58A54F8F58A54F8FUL,
                                       0x66839EAC66839EACUL, 0x31DA3FB931DA3FB9UL, 0x6B9D63A06B9D63AUL,
                                       0x4A6982944A698294UL, 0x123A4997123A4997UL, 0x770058CD770058CDUL,
                                       0x688EF3DF688EF3DFUL, 0x3195486931954869UL, 0x169B665F169B665FUL,
                                       0x3149F96E3149F96EUL, 0x32B21A9A32B21A9AUL, 0x70BD1C0F70BD1C0FUL,
                                       0x63A7462963A74629UL, 0x4D9017804D901780UL, 0x12C34C4612C34C46UL,
                                       0x6EFC940E6EFC940EUL, 0xAC4825E0AC4825EUL, 0x4FB451CF4FB451CFUL,
                                       0x2B08135B2B08135BUL, 0x7A551D097A551D09UL, 0x431DE7B0431DE7BUL,
                                       0x7E17888A7E17888AUL, 0xD55D5750D55D575UL, 0x162BA485162BA485UL,
                                       0x53FE09C653FE09C6UL, 0x27B3332E27B3332EUL, 0x7EDAD1307EDAD13UL,
                                       0x92F326C092F326CUL, 0x3E28AD403E28AD4UL, 0x5B9E43EF5B9E43EFUL,
                                       0x5C30B5555C30B555UL, 0x2FC3B8F12FC3B8F1UL, 0x3752590A3752590AUL,
                                       0x649C9BE1649C9BE1UL, 0x5CD4967E5CD4967EUL, 0xB0A081F0B0A081FUL,
                                       0x2AC65D282AC65D28UL, 0x133BA41C133BA41CUL, 0x1B167D0D1B167D0DUL,
                                       0x48BA889A48BA889AUL, 0x2FAA8D362FAA8D36UL, 0x4A82413B4A82413BUL,
                                       0x178C392D178C392DUL, 0x6DCEAB086DCEAB08UL, 0x78C75F3F78C75F3FUL,
                                       0x2EAF5B8F2EAF5B8FUL, 0x8CAF21808CAF218UL, 0x7C148CFE7C148CFEUL,
                                       0x59585B8859585B88UL, 0x1435417414354174UL, 0x6D4E08A06D4E08A0UL,
                                       0x25F329F925F329F9UL, 0x69F88FF069F88FF0UL, 0x16B5B1E716B5B1E7UL,
                                       0x2086893D2086893DUL, 0x349F124A349F124AUL, 0x7E4EBE0F7E4EBE0FUL,
                                       0x658639B2658639B2UL, 0x712AB097712AB097UL, 0xB94ED3D0B94ED3DUL,
                                       0x4064C89C4064C89CUL, 0xA6DFDA30A6DFDA3UL, 0x297EDDE9297EDDE9UL,
                                       0x6AA9CB606AA9CB60UL, 0x1203E4F11203E4F1UL, 0x6AA0A15C6AA0A15CUL,
                                       0x452F5ABC452F5ABCUL, 0x70F6A01270F6A012UL, 0x5EF13C815EF13C81UL,
                                       0x4272F5D44272F5D4UL, 0x21A258F421A258F4UL, 0x1A5EF7DD1A5EF7DDUL,
                                       0x6343A9036343A903UL, 0x5F3191D65F3191D6UL, 0x144C2DFD144C2DFDUL,
                                       0x17DA1F4417DA1F44UL, 0x3BCF29913BCF2991UL, 0x4E123CFD4E123CFDUL,
                                       0x2F0656CE2F0656CEUL, 0x6A8C46776A8C4677UL, 0x435B5297435B5297UL,
                                       0x6DF1EB3A6DF1EB3AUL, 0x3168624B3168624BUL, 0x4EBFC2E24EBFC2E2UL,
                                       0x55C9182955C91829UL, 0x5C62C3DB5C62C3DBUL, 0xDF8FFD70DF8FFD7UL,
                                       0x7B36B0F67B36B0F6UL, 0x7A81B16F7A81B16FUL, 0x38C2A03338C2A033UL,
                                       0x39BB9FC539BB9FC5UL, 0x5D8201DC5D8201DCUL, 0x6C9731286C973128UL,
                                       0x1871F4EE1871F4EEUL, 0x5B71D37C5B71D37CUL, 0x64FE1A3C64FE1A3CUL,
                                       0x7E3B163B7E3B163BUL, 0x4DEFBF354DEFBF35UL, 0x2E5D970B2E5D970BUL,
                                       0x2D53F15A2D53F15AUL, 0x1F3463021F346302UL, 0x3190675F3190675FUL,
                                       0x75AC65C975AC65C9UL, 0x201D69CF201D69CFUL, 0x5950DEDD5950DEDDUL,
                                       0x604A6147604A6147UL, 0x3C2EB6753C2EB675UL, 0x19C9869E19C9869EUL,
                                       0x3CFBCF843CFBCF84UL, 0x5E48828A5E48828AUL, 0x804DBFC0804DBFCUL,
                                       0x4328637843286378UL, 0x8472B0008472B00UL, 0x2137B00E2137B00EUL,
                                       0x4FDD62024FDD6202UL, 0x1D7898EF1D7898EFUL, 0x1B81CC1D1B81CC1DUL,
                                       0xE37934C0E37934CUL, 0x229EE93D229EE93DUL, 0x57EB6A6E57EB6A6EUL,
                                       0x3E40E3833E40E383UL, 0x68CFDE0168CFDE01UL, 0x29D4A1AB29D4A1ABUL,
                                       0x2349BC5E2349BC5EUL, 0x693B9DE9693B9DE9UL, 0x5AA361235AA36123UL,
                                       0x641C770C641C770CUL, 0x3F1E7CC13F1E7CC1UL, 0x2D9734E22D9734E2UL,
                                       0x2558070C2558070CUL, 0x368743D3368743D3UL, 0x4FD55D884FD55D88UL,
                                       0x3FBEB3B83FBEB3B8UL, 0x5DCBFDEF5DCBFDEFUL, 0xD53F5410D53F541UL,
                                       0x1FDCBB7A1FDCBB7AUL, 0x7100692871006928UL, 0x17FCEEE017FCEEE0UL,
                                       0x6AB3DE216AB3DE21UL, 0x32AB9D8F32AB9D8FUL, 0x1AF119A61AF119A6UL,
                                       0x238B1E30238B1E3UL, 0x2666EB012666EB01UL, 0x340FB327340FB327UL,
                                       0xD0AB65A0D0AB65AUL, 0x174AF42C174AF42CUL, 0x22C2A9B722C2A9B7UL,
                                       0x4C7B92714C7B9271UL, 0x7FEFE6297FEFE629UL, 0x797F88D7797F88D7UL,
                                       0x76485D8676485D86UL, 0x5B1DB3005B1DB300UL, 0x3DD41F4C3DD41F4CUL,
                                       0x6CE30A796CE30A79UL, 0x11787BAE11787BAEUL, 0x5FB452795FB45279UL,
                                       0x4D9E54A44D9E54A4UL, 0x627199CC627199CCUL, 0x184BE9F0184BE9FUL,
                                       0x3F2458D93F2458D9UL, 0xDB705F90DB705F9UL, 0x63FEA2AA63FEA2AAUL,
                                       0xEEC3F1B0EEC3F1BUL, 0x321F7EA3321F7EA3UL, 0x365B6D90365B6D9UL,
                                       0x23CA6D4023CA6D40UL, 0x5C2A5FE25C2A5FE2UL, 0x953836009538360UL,
                                       0x74B557A774B557A7UL, 0x4C584E9B4C584E9BUL, 0x6EAF20616EAF2061UL,
                                       0x42C5296D42C5296DUL, 0x12FD06A712FD06A7UL, 0x3A025F643A025F64UL,
                                       0x60171B5C60171B5CUL, 0x42D556DC42D556DCUL, 0x4B401A624B401A62UL,
                                       0x1C3025561C302556UL, 0x5399F8855399F885UL, 0x3801BA613801BA61UL,
                                       0x7103E2BB7103E2BBUL, 0x120FF820120FF82UL, 0x23F0105123F01051UL,
                                       0x688C11EB688C11EBUL, 0x50A31C3250A31C32UL, 0x5D68267F5D68267FUL,
                                       0x5E79C5B95E79C5B9UL, 0x4516F8004516F8UL, 0x400324E3400324E3UL,
                                       0x70E47FF970E47FF9UL, 0x48307A2148307A21UL, 0x249918CD249918CDUL,
                                       0x2600B85F2600B85FUL, 0x294A2630294A2630UL, 0x3D44DBA03D44DBAUL,
                                       0x143A2F67143A2F67UL, 0x4981A1484981A148UL, 0x50ED581D50ED581DUL,
                                       0xC84DD0C0C84DD0CUL, 0xBCDCC0E0BCDCC0EUL, 0x338D68B3338D68B3UL,
                                       0x7B8FFEB47B8FFEB4UL, 0xB9EFA200B9EFA20UL, 0x1E20DAFA1E20DAFAUL,
                                       0x17AF458B17AF458BUL, 0x12E2F26E12E2F26EUL, 0x6A541A406A541A40UL,
                                       0x76BA0E7076BA0E7UL, 0x256373B5256373B5UL, 0x3B4E39A33B4E39A3UL,
                                       0x2A7ADB452A7ADB45UL, 0x41A2AA5041A2AA50UL, 0x545A572E545A572EUL,
                                       0x7137840A7137840AUL, 0x669BBF4B669BBF4BUL, 0x80BADD5080BADD5UL,
                                       0x53ACA44253ACA442UL, 0x357E8BF9357E8BF9UL, 0x2FC5BEE12FC5BEE1UL,
                                       0x288AE316288AE316UL, 0x35CD23CD35CD23CDUL, 0x108841BA108841BAUL,
                                       0x7EF470617EF47061UL, 0x40A22C7C40A22C7CUL, 0xD3362740D336274UL,
                                       0x6F992A496F992A49UL, 0x6A5089BB6A5089BBUL, 0x24BA06A224BA06A2UL,
                                       0x6EDEF4CC6EDEF4CCUL, 0x90B9025090B9025UL, 0x6950780C6950780CUL,
                                       0x3FAC11793FAC1179UL, 0x53DCB3F253DCB3F2UL, 0x5AF3A3DD5AF3A3DDUL,
                                       0x5458716A5458716AUL, 0x5E199A7F5E199A7FUL, 0x5EF41CF95EF41CF9UL,
                                       0x1FB0603E1FB0603EUL, 0x7B32BA827B32BA82UL, 0x3C67D12E3C67D12EUL,
                                       0x2D2679602D26796UL, 0x1458D9F01458D9FUL, 0x41BA42E341BA42E3UL, 
                                       0x5F7F85805F7F858UL, 0x5EE69AB55EE69AB5UL, 0x243EDE5D243EDE5DUL, 0x39DED0BC39DED0BCUL,
                                       0x38B4161738B41617UL, 0x7B63AAAE7B63AAAEUL, 0x39A8F6A939A8F6A9UL,
                                       0x4E44B5404E44B540UL, 0x1F068D3B1F068D3BUL, 0x610D955D610D955DUL,
                                       0x3BC557293BC55729UL, 0xAF04BFF0AF04BFFUL, 0x4C5CBBB84C5CBBB8UL,
                                       0x7C8D337D7C8D337DUL, 0xBC22F200BC22F20UL, 0x6EB2A14C6EB2A14CUL,
                                       0x5C4B2D915C4B2D91UL, 0x6F2817876F281787UL, 0x6926DCBB6926DCBBUL,
                                       0x2C35A4C92C35A4C9UL, 0x187A64A0187A64A0UL, 0x3D517D8D3D517D8DUL,
                                       0x5D9EE7415D9EE741UL, 0x12D2B25412D2B254UL, 0x454F509D454F509DUL,
                                       0x6A5B6A056A5B6A05UL, 0x448CF8C9448CF8C9UL, 0x7AEAED907AEAED9UL,
                                       0x66FCB69366FCB693UL, 0x550D98A5550D98A5UL, 0x6AC9B2506AC9B25UL,
                                       0x4529A7A14529A7A1UL, 0x7763C0E07763C0EUL, 0x6A081E676A081E67UL,
                                       0x1BA1332D1BA1332DUL, 0x966795E0966795EUL, 0x3A55C79E3A55C79EUL,
                                       0x15A0243A15A0243AUL, 0x63B3728163B37281UL, 0x2139BC5A2139BC5AUL,
                                       0x368FF6E9368FF6E9UL, 0x394D1800394D1800UL, 0x70D3128A70D3128AUL,
                                       0x6578313E6578313EUL, 0x48904C9D48904C9DUL, 0x2884CDBB2884CDBBUL,
                                       0x19A4831219A48312UL, 0x58CF439758CF4397UL, 0x1A7763E81A7763E8UL,
                                       0x1320A8741320A874UL, 0x561514C0561514CUL, 0x62D9A75562D9A755UL,
                                       0x7798745B7798745BUL, 0xD9F17500D9F175UL, 0x1F28FA961F28FA96UL,
                                       0x7B21A8677B21A867UL, 0x66FB583066FB583UL, 0xACBA0950ACBA095UL,
                                       0x42FFC36F42FFC36FUL, 0x5B774ADD5B774ADDUL, 0x656F69D3656F69D3UL,
                                       0x3607F98C3607F98CUL, 0x34B7E55734B7E557UL, 0x776F74B7776F74B7UL,
                                       0x24FA3BC724FA3BC7UL, 0x69F48A0069F48AUL, 0x68BE62A168BE62A1UL,
                                       0x72108BEA72108BEAUL, 0x639352BC639352BCUL, 0x3B17DCBB3B17DCBBUL,
                                       0x3C97B6A33C97B6A3UL, 0x7FAB95B27FAB95B2UL, 0x6F95E8226F95E822UL,
                                       0x15A4A46715A4A467UL, 0x7462AAD47462AAD4UL, 0x37E73E2C37E73E2CUL,
                                       0x3C83A8C03C83A8C0UL, 0x541AB89F541AB89FUL, 0x631B6A93631B6A93UL,
                                       0x32675A0432675A04UL, 0x5A6A912D5A6A912DUL, 0x33282F1933282F19UL,
                                       0x2E5C16902E5C1690UL, 0x4F4E883B4F4E883BUL, 0x3B0119E13B0119E1UL,
                                       0x431CE476431CE476UL, 0x26078A5726078A57UL, 0x6393A5D96393A5D9UL,
                                       0x38677DBB38677DBBUL, 0x416958B2416958B2UL, 0xE805D290E805D29UL,
                                       0x4A4ABC124A4ABC12UL, 0x11ADFE2E11ADFE2EUL, 0x17204E1A17204E1AUL,
                                       0x256CE973256CE973UL, 0x4515B2484515B248UL, 0x5B156FD35B156FD3UL,
                                       0x4B7FBC304B7FBC3UL, 0x4912BCE64912BCE6UL, 0x648E9C60648E9C60UL,
                                       0xB1C9A2E0B1C9A2EUL, 0x21A0B34D21A0B34DUL, 0xB2558530B255853UL,
                                       0x48186BA748186BA7UL, 0x18B9724B18B9724BUL, 0x57DD10EC57DD10ECUL,
                                       0x4543FA5C4543FA5CUL, 0x4CA377304CA3773UL, 0x2B0FF1732B0FF173UL,
                                       0x16CFFFF616CFFFF6UL, 0x70AAE41E70AAE41EUL, 0x11A69E9411A69E94UL,
                                       0x970014909700149UL, 0x45CD1A2945CD1A29UL, 0x2AE735F72AE735F7UL,
                                       0x6433B0986433B098UL, 0x5542F47D5542F47DUL, 0x2146B2E32146B2E3UL,
                                       0x5A6922975A692297UL, 0x292D6151292D6151UL, 0x267D9E4B267D9E4BUL,
                                       0x3A7DF56A3A7DF56AUL, 0x423B5D44423B5D44UL, 0x243B71C2243B71C2UL,
                                       0x6A5F1C2F6A5F1C2FUL, 0x3004E5733004E573UL, 0x22EB933522EB9335UL,
                                       0x5B1EC1615B1EC161UL, 0x6144B9476144B947UL, 0x5B5D87495B5D8749UL,
                                       0x174A3290174A3290UL, 0x38103D1838103D18UL, 0x705383A8705383A8UL,
                                       0x23916F9F23916F9FUL, 0x54C1462054C14620UL, 0x6673501A6673501AUL,
                                       0x4064F7914064F791UL, 0xC7ECEEE0C7ECEEEUL, 0x527724EB527724EBUL,
                                       0x776DC1DA776DC1DAUL, 0x27812EB327812EB3UL, 0x7CCDE51C7CCDE51CUL,
                                       0x793409C0793409C0UL, 0x625717B6625717B6UL, 0x498D4C70498D4C7UL,
                                       0x39DEC28F39DEC28FUL, 0x227F8314227F8314UL, 0x1504B2C61504B2C6UL,
                                       0x19A70F9519A70F95UL, 0x270CEE8E270CEE8EUL, 0x38931B3538931B35UL,
                                       0x680BF7C1680BF7C1UL, 0x952A5E30952A5E3UL, 0x65895C8A65895C8AUL,
                                       0x1EAD568E1EAD568EUL, 0x673B89E7673B89E7UL, 0x51B16A0D51B16A0DUL,
                                       0x50A1F76150A1F761UL, 0x4ECEC1904ECEC190UL, 0x145AF81D145AF81DUL,
                                       0x1C432B971C432B97UL, 0x4F2E49AB4F2E49ABUL, 0x30FFD9D330FFD9D3UL,
                                       0x550D5845550D5845UL, 0x187FD1AD187FD1ADUL, 0x167815FE167815FEUL,
                                       0x2FCE57652FCE5765UL, 0x3457F7AF3457F7AFUL, 0x6558E10B6558E10BUL,
                                       0x5387686653876866UL, 0x4398ECA74398ECA7UL, 0x70CA8AB370CA8AB3UL,
                                       0x59B3EC2159B3EC21UL, 0xBC1471B0BC1471BUL, 0x36D7708F36D7708FUL,
                                       0x4F075E514F075E51UL, 0x23EB5CDC23EB5CDCUL, 0x69D7A8BF69D7A8BFUL,
                                       0x552C5530552C5530UL, 0x4B2D379B4B2D379BUL, 0x6D8BDAB06D8BDAB0UL,
                                       0x24CE433124CE4331UL, 0x67177AAB67177AABUL, 0x58F1C20058F1C20UL,
                                       0x27A2CBAF27A2CBAFUL, 0x45367C8445367C84UL, 0x2024AC3E2024AC3EUL,
                                       0x35FF87A035FF87AUL, 0x4829434848294348UL, 0x62878C4762878C47UL,
                                       0x650856506508565UL, 0x193FA3EC193FA3ECUL, 0x1ED0F2D31ED0F2D3UL,
                                       0x46C0C22E46C0C22EUL, 0x1687C5A81687C5A8UL, 0x49BE3FD749BE3FD7UL,
                                       0x38349E8738349E87UL, 0x6AEE78E06AEE78E0UL, 0x6320E72A6320E72AUL,
                                       0x16453F7216453F72UL, 0x5E8CB9FB5E8CB9FBUL, 0x7922770479227704UL,
                                       0x3CAE93323CAE9332UL, 0x697CE0FF697CE0FFUL, 0x5544F49B5544F49BUL,
                                       0x627697DC627697DCUL, 0x471A8412471A8412UL, 0x15E5DCF215E5DCF2UL,
                                       0x17FAF6D517FAF6D5UL, 0x228415BF228415BFUL, 0x3E0076F73E0076F7UL,
                                       0x49305A9049305A90UL, 0x3D66FBF63D66FBF6UL, 0x24752F9224752F92UL,
                                       0x4CB4F2104CB4F210UL, 0x6394608D6394608DUL, 0x5F9619415F961941UL,
                                       0x314F2CA9314F2CA9UL, 0x24972DB324972DB3UL, 0x3509068635090686UL,
                                       0x7E6782167E678216UL, 0x757F7D85757F7D85UL, 0x5316723153167231UL,
                                       0x2B19EFF02B19EFFUL, 0x24D205DA24D205DAUL, 0x47AEC05F47AEC05FUL,
                                       0x7A18DA697A18DA69UL, 0x3F3ADC0D3F3ADC0DUL, 0x487ABDF7487ABDF7UL,
                                       0x4EF251684EF25168UL, 0xA9955900A995590UL, 0x77273E3A77273E3AUL,
                                       0x690A6C02690A6C02UL, 0x1B658ACB1B658ACBUL, 0x178811D2178811D2UL,
                                       0x497A3621497A3621UL, 0x693D1E80693D1E8UL, 0x57D5896A57D5896AUL,
                                       0x27A2468327A24683UL, 0x6F2907056F290705UL, 0x2454888C2454888CUL,
                                       0x599CB0C5599CB0C5UL, 0x8635C1708635C17UL, 0x7143829071438290UL,
                                       0x15C830DE15C830DEUL, 0x42396AE642396AE6UL, 0x7A6838547A683854UL,
                                       0x5018617F5018617FUL, 0x612E962D612E962DUL, 0x6E52F21F6E52F21FUL,
                                       0x731A2E80731A2E80UL, 0x2A18C9CC2A18C9CCUL, 0x3281F89F3281F89FUL,
                                       0x17057B0317057B03UL, 0x1489A1E11489A1E1UL, 0x4384CEC44384CEC4UL,
                                       0x684E23EE684E23EEUL, 0x54CDB66C54CDB66CUL, 0x4C9DAB8B4C9DAB8BUL,
                                       0x3A08C7DA3A08C7DAUL, 0x780660EE780660EEUL, 0x38F24B5138F24B51UL,
                                       0x7300FE187300FE18UL, 0x77DB680D77DB680DUL, 0x798EAEAD798EAEADUL,
                                       0x65B75E8B65B75E8BUL, 0x58D0011D58D0011DUL, 0x400A1D97400A1D97UL,
                                       0x2C9FC8862C9FC886UL, 0x3CCFFA423CCFFA42UL, 0x5CBF263C5CBF263CUL,
                                       0x419F055C419F055CUL, 0x6D714FAA6D714FAAUL, 0x597FD4A3597FD4A3UL,
                                       0x7189AE7F7189AE7FUL, 0x6E8AC6666E8AC666UL, 0x614D6992614D6992UL,
                                       0x32E3794932E37949UL, 0x20EE5E2220EE5E22UL, 0x6E06ACC96E06ACC9UL,
                                       0x3895DF2F3895DF2FUL, 0x453B792A453B792AUL, 0x15F386F215F386F2UL,
                                       0x448E009D448E009DUL, 0x5C66D6085C66D608UL, 0x903690D0903690DUL,
                                       0x26663A4D26663A4DUL, 0x3B0A48C53B0A48C5UL, 0x6CA715656CA71565UL,
                                       0x2FF6BEA12FF6BEA1UL, 0x65DE826265DE8262UL, 0x6D4F6C276D4F6C27UL,
                                       0xFFBC8BA0FFBC8BAUL, 0x5A9E5BFC5A9E5BFCUL, 0x4BD4BFEC4BD4BFECUL,
                                       0xCA67F610CA67F61UL, 0x2FBC518D2FBC518DUL, 0x75B2F2B075B2F2BUL,
                                       0x4FCA156D4FCA156DUL, 0x54808E3054808E30UL, 0x219C5308219C5308UL,
                                       0x195C8C77195C8C77UL, 0x3DA01BE53DA01BE5UL, 0x703DEB1A703DEB1AUL,
                                       0x1DDC18DA1DDC18DAUL, 0x7147DAA77147DAA7UL, 0x60A0DA3F60A0DA3FUL,
                                       0x2E8268612E826861UL, 0x321DBC14321DBC14UL, 0x4C62203C4C62203CUL,
                                       0x67DB1BD867DB1BD8UL, 0x4F23087D4F23087DUL, 0x340BADF3340BADF3UL,
                                       0x69D2BACC69D2BACCUL, 0x785D2994785D2994UL, 0x15E98DD415E98DD4UL,
                                       0x75D735DE75D735DEUL, 0x7A3AF8607A3AF860UL, 0x5E62627B5E62627BUL,
                                       0x3A9CA6643A9CA664UL, 0x2EFC2BF52EFC2BF5UL, 0x62B8F58062B8F58UL,
                                       0x45A88A3545A88A35UL, 0x6579365265793652UL, 0x647FCD30647FCD30UL,
                                       0x44F4AFA444F4AFA4UL, 0x2D081A6A2D081A6AUL, 0x753FF95E753FF95EUL,
                                       0x487CC3A0487CC3AUL, 0x44B27DE744B27DE7UL, 0x1DE60FAC1DE60FACUL,
                                       0x70E5890D70E5890DUL, 0x5199EB955199EB95UL, 0x4F7E06E64F7E06E6UL,
                                       0x7978477B7978477BUL, 0x74D2DD7774D2DD77UL, 0x7543488775434887UL,
                                       0x1C7B65461C7B6546UL, 0x6EE7BCF16EE7BCF1UL, 0x3868779A3868779AUL,
                                       0x39614DB939614DB9UL, 0x6938B05B6938B05BUL, 0x1B5976901B59769UL,
                                       0xEEE0BC50EEE0BC5UL, 0x719D42B4719D42B4UL, 0x5D0113095D011309UL,
                                       0x63CA38E363CA38E3UL, 0x4EEC7CD54EEC7CD5UL, 0x57F2149B57F2149BUL,
                                       0x569CEB53569CEB53UL, 0x7D09F2047D09F204UL, 0x3AE4997F3AE4997FUL,
                                       0x10F55A5110F55A51UL, 0x5F83675D5F83675DUL, 0x18EF30C818EF30C8UL,
                                       0x7EC09CD57EC09CD5UL, 0x7816D48B7816D48BUL, 0x22CAE96422CAE964UL,
                                       0x5E4D5CDA5E4D5CDAUL, 0x2489352224893522UL, 0x1D2CBD361D2CBD36UL,
                                       0x73DEBC4373DEBC43UL, 0x78181F9178181F91UL, 0x647B5A00647B5A00UL,
                                       0x4EEB9B664EEB9B66UL, 0xA2EBD9F0A2EBD9FUL, 0x1741974317419743UL,
                                       0x2539C9C02539C9C0UL, 0x5438924254389242UL, 0x2A038CB42A038CB4UL,
                                       0x681A8E12681A8E12UL, 0x4925F1C84925F1C8UL, 0x5976AD0A5976AD0AUL,
                                       0x1AA9FB2D1AA9FB2DUL, 0x7A983B597A983B59UL, 0x51E67C9E51E67C9EUL,
                                       0x7195BF3E7195BF3EUL, 0xA0BA8D90A0BA8D9UL, 0x69D6075A69D6075AUL,
                                       0x7D7A2A517D7A2A51UL, 0x5527814555278145UL, 0x315A66B4315A66B4UL,
                                       0x5B1249675B124967UL, 0x796B3ADE796B3ADEUL, 0x508BD7A3508BD7A3UL,
                                       0x74557F0F74557F0FUL, 0x50B53D2350B53D23UL, 0x26D6951A26D6951AUL,
                                       0x142B4E2E142B4E2EUL, 0x8315700083157UL, 0x65D5D3EA65D5D3EAUL, 0xFCBCABE0FCBCABEUL,
                                       0x13CE1B1213CE1B12UL, 0x753F7BE7753F7BE7UL, 0x2152FA742152FA74UL,
                                       0x2FA398692FA39869UL, 0x28539C0528539C05UL, 0x69FCD94E69FCD94EUL,
                                       0x72C8207A72C8207AUL, 0x177BD89E177BD89EUL, 0x6BBC3C576BBC3C57UL,
                                       0x4F1737C64F1737C6UL
                                   };

        /// <summary>
        /// Generates <a href="http://chessprogramming.wikispaces.com/Zobrist+Hashing">Zobrist hash keys</a> for the specified piece.
        /// </summary>
        /// <param name="piece">The piece.</param>
        public void Generate(Piece piece)
        {
            // Populate hash keys for piece
            for (var rank = 0; rank < 8; rank++)
            {
                for (var file = 0; file < 8; file++)
                {
                    var whiteIndex = this.GetKeyIndex(piece, rank, file, Side.White);
                    var blackIndex = this.GetKeyIndex(piece, rank, file, Side.Black);

                    piece.ZobristHashKeys.White[rank << 4 | file] = this.keys[whiteIndex];
                    piece.ZobristHashKeys.Black[rank << 4 | file] = this.keys[blackIndex];
                }
            }

            // Populate hash keys for castling if piece implements ICastleable
            if (piece is ICastleable)
            {
                ((ICastleable)piece).ZobristHashKeysForCastling = this.GenerateHashKeysForCastling();
            }
        }

        /// <summary>
        /// Generates hash keys for en passant moves.
        /// </summary>
        /// <returns>A list of hash keys for en passant moves.</returns>
        public ulong[] GenerateHashKeysForEnPassant()
        {
            var l = new ulong[8];

            const int Offset = 772;

            for (var i = 0; i < 8; ++i)
            {
                l[i] = this.keys[Offset + i];
            }

            return l;
        }

        /// <summary>
        /// Generates hash keys for castling moves.
        /// </summary>
        /// <returns>A list of hash keys for castling moves.</returns>
        public ulong[] GenerateHashKeysForCastling()
        {
            var l = new ulong[16];

            const int Offset = 768;

            for (var i = 0; i < 16; ++i)
            {
                if (0 != (i & (int)CastlingAvailability.KingSideBlack))
                {
                    l[i] ^= this.keys[Offset + 2];
                }

                if (0 != (i & (int)CastlingAvailability.KingSideWhite))
                {
                    l[i] ^= this.keys[Offset + 0];
                }

                if (0 != (i & (int)CastlingAvailability.QueenSideBlack))
                {
                    l[i] ^= this.keys[Offset + 3];
                }

                if (0 != (i & (int)CastlingAvailability.QueenSideWhite))
                {
                    l[i] ^= this.keys[Offset + 1];
                }
            }

            return l;
        }

        /// <summary>
        /// Gets the index of the Zobrist key for the specified piece in the specified position.
        /// </summary>
        /// <param name="piece">The piece.</param>
        /// <param name="rank">The rank.</param>
        /// <param name="file">The file.</param>
        /// <param name="owner">The owner.</param>
        /// <returns>The key index.</returns>
        private int GetKeyIndex(Piece piece, int rank, int file, Side owner)
        {
            var index = 0;

            if (piece is Pawn)
            {
                index = 0;
            }
            else if (piece is Knight)
            {
                index = 2;
            }
            else if (piece is Bishop)
            {
                index = 4;
            }
            else if (piece is Rook)
            {
                index = 6;
            }
            else if (piece is Queen)
            {
                index = 8;
            }
            else if (piece is King)
            {
                index = 10;
            }

            if (owner == Side.White)
            {
                index++;
            }

            return (64 * index) + (8 * rank) + file;
        }
    }
}