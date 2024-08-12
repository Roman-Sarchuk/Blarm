using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

public class ColorTypeConverter : TypeConverter
{
    public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
    {
        return true;
    }

    public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    {
        // Повертає список доступних кольорів
        return new StandardValuesCollection(new List<BlarmWF.StatusName>
        {
            BlarmWF.StatusName.On,
            BlarmWF.StatusName.Mute,
            BlarmWF.StatusName.Off
        });
    }

    public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
    {
        return true;
    }
}