using System;
using UnityEngine;

// Token: 0x020000AD RID: 173
[Serializable]
public class HomeClockScript : MonoBehaviour
{
	// Token: 0x060003CC RID: 972 RVA: 0x0004C1D0 File Offset: 0x0004A3D0
	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("Weekday") == 1)
		{
			this.DayLabel.text = "MONDAY";
		}
		else if (PlayerPrefs.GetInt("Weekday") == 2)
		{
			this.DayLabel.text = "TUESDAY";
		}
		else if (PlayerPrefs.GetInt("Weekday") == 3)
		{
			this.DayLabel.text = "WEDNESDAY";
		}
		else if (PlayerPrefs.GetInt("Weekday") == 4)
		{
			this.DayLabel.text = "THURSDAY";
		}
		else if (PlayerPrefs.GetInt("Weekday") == 5)
		{
			this.DayLabel.text = "FRIDAY";
		}
		if (PlayerPrefs.GetInt("Night") == 1)
		{
			this.HourLabel.text = "8:00 PM";
		}
		else if (PlayerPrefs.GetInt("Late") == 1)
		{
			this.HourLabel.text = "7:30 AM";
		}
		else
		{
			this.HourLabel.text = "6:30 AM";
		}
	}

	// Token: 0x060003CD RID: 973 RVA: 0x0004C2EC File Offset: 0x0004A4EC
	public virtual void Main()
	{
	}

	// Token: 0x0400097A RID: 2426
	public UILabel HourLabel;

	// Token: 0x0400097B RID: 2427
	public UILabel DayLabel;
}
