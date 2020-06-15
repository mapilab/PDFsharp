using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfSharp.Pdf.AcroForms;
using PdfSharp.Pdf;
using System.IO;
using PdfSharp.Pdf.Annotations;
using PdfSharp.Drawing;

namespace PdfSharp.UnitTests
{
    [TestClass]
    public class PdfTextFieldTests
    {
        [TestMethod]
        public void RenderAppearance()
        {
            PdfDocument testDoc = new PdfDocument();

            PdfTextField tf = new PdfTextField(testDoc);
            tf.Rectangle = new PdfRectangle(new XRect(0, 0, 200, 20));

            PdfPage p1 = testDoc.Pages.Add();
            testDoc.Catalog.AcroForm = new PdfAcroForm(testDoc);
            testDoc.AcroForm.Elements.SetValue(PdfAcroForm.Keys.Fields, new PdfAcroField.PdfAcroFieldCollection(new PdfArray(testDoc)));
            testDoc.AcroForm.Fields.Add(tf, 1);

            tf.Text = "Some Test Text";
            tf.PrepareForSave();

            Assert.IsTrue(tf.Elements.ContainsKey(PdfAnnotation.Keys.AP), "Text Field should have rendered an appearance stream.");
        }


        [TestMethod]
        public void RenderAppearance_Empty()
        {
            PdfDocument testDoc = new PdfDocument();

            PdfTextField tf = new PdfTextField(testDoc);
            tf.Rectangle = new PdfRectangle(new XRect(0, 0, 200, 20));

            PdfPage p1 = testDoc.Pages.Add();
            testDoc.Catalog.AcroForm = new PdfAcroForm(testDoc);
            testDoc.AcroForm.Elements.SetValue(PdfAcroForm.Keys.Fields, new PdfAcroField.PdfAcroFieldCollection(new PdfArray(testDoc)));
            testDoc.AcroForm.Fields.Add(tf, 1);

            tf.Text = "Some Test Text";
            tf.PrepareForSave();

            Assert.IsTrue(tf.Elements.ContainsKey(PdfAnnotation.Keys.AP), "Text Field should have rendered an appearance stream.");

            tf.Text = string.Empty;

            tf.PrepareForSave();

            Assert.IsFalse(tf.Elements.ContainsKey(PdfAnnotation.Keys.AP), "Empty Text Field should NOT have an appearance stream.");
        }
    }
}
