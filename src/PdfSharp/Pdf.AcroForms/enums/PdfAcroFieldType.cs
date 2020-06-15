using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcroFieldKeys = PdfSharp.Pdf.AcroForms.PdfAcroField.Keys;

namespace PdfSharp.Pdf.AcroForms.enums
{
    public enum PdfAcroFieldType
    {
        Unknown,
        PushButton,
        RadioButton,
        CheckBox,
        Text,
        ComboBox,
        ListBox,
        Signature,
    }
}
