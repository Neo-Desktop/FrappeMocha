namespace FrappeMocha.Keygen
{
    public enum LicenseTypes
    {
        Windows3270 = 0x8c,
        Windows5250 = 0x80,
        Windows3812 = 0xa0,
        WindowsTelnet = 0x9b,

        Java3270 = 0x1b + 2,
        Java5250 = 0x1b + 2,
        JavaTelnet = 0x1b,

        Mac3270 = 0x5d,
        Mac5250 = 0x16,
        Mac3812 = 0x22,
        MacTelnet = 0x5e,
        MacKeyboard = 0xa5,

        JavaScript3270 = 0xb3,
        JavaScript5250 = 0xb2,
        JavaScriptTelnet = 0xb4,

        Android3270 = 0x94,
        Android5250 = 0x91,
        AndroidTelnet = 0x96,
        AndroidVnc = 0x92,
        AndroidBarcode = 0x9c,
    }
}