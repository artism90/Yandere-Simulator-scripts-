using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x0200003D RID: 61
[Serializable]
public class DontLetSenpaiNoticeYouScript : MonoBehaviour
{
	// Token: 0x060001C7 RID: 455 RVA: 0x0002144C File Offset: 0x0001F64C
	public virtual void Start()
	{
		while (this.ID < Extensions.get_length(this.Letters))
		{
			this.Letters[this.ID].transform.localScale = new Vector3((float)10, (float)10, (float)1);
			int num = 0;
			Color color = this.Letters[this.ID].color;
			float num2 = color.a = (float)num;
			Color color2 = this.Letters[this.ID].color = color;
			this.Origins[this.ID] = this.Letters[this.ID].transform.localPosition;
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x060001C8 RID: 456 RVA: 0x00021518 File Offset: 0x0001F718
	public virtual void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Proceed = true;
		}
		if (this.Proceed)
		{
			if (this.ID < Extensions.get_length(this.Letters))
			{
				this.Letters[this.ID].transform.localScale = Vector3.MoveTowards(this.Letters[this.ID].transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)100);
				float a = this.Letters[this.ID].color.a + Time.deltaTime * (float)10;
				Color color = this.Letters[this.ID].color;
				float num = color.a = a;
				Color color2 = this.Letters[this.ID].color = color;
				if (this.Letters[this.ID].transform.localScale == new Vector3((float)1, (float)1, (float)1))
				{
					this.audio.PlayOneShot(this.Slam);
					this.ID++;
				}
			}
			this.ShakeID = 0;
			while (this.ShakeID < Extensions.get_length(this.Letters))
			{
				float x = this.Origins[this.ShakeID].x + UnityEngine.Random.Range(-5f, 5f);
				Vector3 localPosition = this.Letters[this.ShakeID].transform.localPosition;
				float num2 = localPosition.x = x;
				Vector3 vector = this.Letters[this.ShakeID].transform.localPosition = localPosition;
				float y = this.Origins[this.ShakeID].y + UnityEngine.Random.Range(-5f, 5f);
				Vector3 localPosition2 = this.Letters[this.ShakeID].transform.localPosition;
				float num3 = localPosition2.y = y;
				Vector3 vector2 = this.Letters[this.ShakeID].transform.localPosition = localPosition2;
				this.ShakeID++;
			}
		}
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x00021768 File Offset: 0x0001F968
	public virtual void Main()
	{
	}

	// Token: 0x040003C1 RID: 961
	public UILabel[] Letters;

	// Token: 0x040003C2 RID: 962
	public Vector3[] Origins;

	// Token: 0x040003C3 RID: 963
	public AudioClip Slam;

	// Token: 0x040003C4 RID: 964
	public bool Proceed;

	// Token: 0x040003C5 RID: 965
	public int ShakeID;

	// Token: 0x040003C6 RID: 966
	public int ID;
}
