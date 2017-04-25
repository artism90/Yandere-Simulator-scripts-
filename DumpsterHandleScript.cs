using System;
using UnityEngine;

// Token: 0x02000088 RID: 136
[Serializable]
public class DumpsterHandleScript : MonoBehaviour
{
	// Token: 0x06000338 RID: 824 RVA: 0x00043150 File Offset: 0x00041350
	public virtual void Start()
	{
		this.Panel.active = false;
	}

	// Token: 0x06000339 RID: 825 RVA: 0x00043160 File Offset: 0x00041360
	public virtual void Update()
	{
		if (this.Prompt.Yandere.PickUp == null && !this.Prompt.Yandere.Dragging && !this.Prompt.Yandere.Carrying)
		{
			this.Prompt.HideButton[3] = false;
		}
		else
		{
			this.Prompt.HideButton[3] = true;
		}
		if (this.Prompt.Circle[3].fillAmount <= (float)0)
		{
			this.Prompt.Circle[3].fillAmount = (float)1;
			this.Prompt.Yandere.DumpsterGrabbing = true;
			this.Prompt.Yandere.DumpsterHandle = this;
			this.Prompt.Yandere.CanMove = false;
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[1].text = "STOP";
			this.PromptBar.Label[5].text = "PUSH / PULL";
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = true;
			this.Grabbed = true;
		}
		if (this.Grabbed)
		{
			this.Prompt.Yandere.transform.rotation = Quaternion.Lerp(this.Prompt.Yandere.transform.rotation, this.GrabSpot.rotation, Time.deltaTime * (float)10);
			if (Vector3.Distance(this.Prompt.Yandere.transform.position, this.GrabSpot.position) > 0.1f)
			{
				this.Prompt.Yandere.MoveTowardsTarget(this.GrabSpot.position);
			}
			else
			{
				this.Prompt.Yandere.transform.position = this.GrabSpot.position;
			}
			if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("DpadX") > 0.5f)
			{
				float z = this.transform.parent.transform.position.z - Time.deltaTime;
				Vector3 position = this.transform.parent.transform.position;
				float num = position.z = z;
				Vector3 vector = this.transform.parent.transform.position = position;
			}
			else if (Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("DpadX") < -0.5f)
			{
				float z2 = this.transform.parent.transform.position.z + Time.deltaTime;
				Vector3 position2 = this.transform.parent.transform.position;
				float num2 = position2.z = z2;
				Vector3 vector2 = this.transform.parent.transform.position = position2;
			}
			if (this.PullLimit < this.PushLimit)
			{
				if (this.transform.parent.transform.position.z < this.PullLimit)
				{
					float pullLimit = this.PullLimit;
					Vector3 position3 = this.transform.parent.transform.position;
					float num3 = position3.z = pullLimit;
					Vector3 vector3 = this.transform.parent.transform.position = position3;
				}
				else if (this.transform.parent.transform.position.z > this.PushLimit)
				{
					float pushLimit = this.PushLimit;
					Vector3 position4 = this.transform.parent.transform.position;
					float num4 = position4.z = pushLimit;
					Vector3 vector4 = this.transform.parent.transform.position = position4;
				}
			}
			else if (this.transform.parent.transform.position.z > this.PullLimit)
			{
				float pullLimit2 = this.PullLimit;
				Vector3 position5 = this.transform.parent.transform.position;
				float num5 = position5.z = pullLimit2;
				Vector3 vector5 = this.transform.parent.transform.position = position5;
			}
			else if (this.transform.parent.transform.position.z < this.PushLimit)
			{
				float pushLimit2 = this.PushLimit;
				Vector3 position6 = this.transform.parent.transform.position;
				float num6 = position6.z = pushLimit2;
				Vector3 vector6 = this.transform.parent.transform.position = position6;
			}
			if (this.DumpsterLid.transform.position.z > this.DumpsterLid.DisposalSpot - 0.05f && this.DumpsterLid.transform.position.z < this.DumpsterLid.DisposalSpot + 0.05f)
			{
				this.Panel.active = true;
			}
			else
			{
				this.Panel.active = false;
			}
			if (Input.GetButtonDown("B"))
			{
				this.Prompt.Yandere.DumpsterGrabbing = false;
				this.Prompt.Yandere.CanMove = true;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
				this.Panel.active = false;
				this.Grabbed = false;
			}
		}
	}

	// Token: 0x0600033A RID: 826 RVA: 0x00043758 File Offset: 0x00041958
	public virtual void Main()
	{
	}

	// Token: 0x04000813 RID: 2067
	public DumpsterLidScript DumpsterLid;

	// Token: 0x04000814 RID: 2068
	public PromptBarScript PromptBar;

	// Token: 0x04000815 RID: 2069
	public PromptScript Prompt;

	// Token: 0x04000816 RID: 2070
	public Transform GrabSpot;

	// Token: 0x04000817 RID: 2071
	public GameObject Panel;

	// Token: 0x04000818 RID: 2072
	public bool Grabbed;

	// Token: 0x04000819 RID: 2073
	public float Direction;

	// Token: 0x0400081A RID: 2074
	public float PullLimit;

	// Token: 0x0400081B RID: 2075
	public float PushLimit;
}
