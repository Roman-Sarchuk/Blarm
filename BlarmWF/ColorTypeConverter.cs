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
        return new StandardValuesCollection(new List<BlarmWF.ColorStatusName>
        {
            BlarmWF.ColorStatusName.On,
            BlarmWF.ColorStatusName.Mute,
            BlarmWF.ColorStatusName.Off
        });
    }

    public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
    {
        return true;
    }
}