using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public struct LedgerEntry
{
    public LedgerEntry(DateTime date, string desc, float chg)
    {
        Date = date;
        Desc = desc;
        Chg = chg;
    }

    public DateTime Date { get; }
    public string Desc { get; }
    public float Chg { get; }
}

public static class Ledger
{
    public static LedgerEntry CreateEntry(string date, string desc, int chng)
    {
        return new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0f);
    }

    private static CultureInfo CreateCulture(string cur, string loc)
    {
        if ((cur != "USD" && cur != "EUR") || (loc != "nl-NL" && loc != "en-US"))
            throw new ArgumentException("Invalid currency");

        var culture = new CultureInfo(loc){
            
        };
        culture.NumberFormat.CurrencySymbol = (cur == "USD") ? "$" : "€";
        culture.NumberFormat.CurrencyNegativePattern = (loc == "nl-NL") ? 12 : 0;
        culture.DateTimeFormat.ShortDatePattern = (loc == "nl-NL") ? "dd/MM/yyyy" : "MM/dd/yyyy";
        return culture;
    }

    private static string PrintHead(string loc)
    {
        if (loc != "nl-NL" && loc != "en-US")
            throw new ArgumentException("Invalid currency");

        return (loc == "en-US")
            ? "Date       | Description               | Change       "
            : "Datum      | Omschrijving              | Verandering  ";
    }

    private static string Description(string desc) => desc.Length > 25 ? desc.Substring(0, 22) + "..." : desc;

    private static string Change(IFormatProvider culture, float cgh) => cgh < 0.0 ? cgh.ToString("C", culture) : cgh.ToString("C", culture) + " ";

    private static string PrintEntry(IFormatProvider culture, LedgerEntry entry) =>
        entry.Date.ToString("d", culture) + " | " + string.Format("{0,-25}", Description(entry.Desc)) + " | " + string.Format("{0,13}", Change(culture, entry.Chg));

    private static IEnumerable<LedgerEntry> Sort(LedgerEntry[] entries) =>
        entries.OrderBy(x => x.Date + "@" + x.Desc + "@" + x.Chg).OrderBy(e => Math.Sign(e.Chg));

    public static string Format(string currency, string locale, LedgerEntry[] entries) =>
        string.Join('\n', new string[] { PrintHead(locale) }
            .Concat(Sort(entries).Select(e => PrintEntry(CreateCulture(currency, locale), e))));
}
