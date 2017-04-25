using System;
using UnityEngine;

// Token: 0x0200007B RID: 123
[Serializable]
public class DemonPortalScript : MonoBehaviour
{
	// Token: 0x060002FF RID: 767 RVA: 0x0003DC58 File Offset: 0x0003BE58
	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Yandere.Character.animation.CrossFade(this.Yandere.IdleAnim);
			this.Yandere.CanMove = false;
			UnityEngine.Object.Instantiate(this.DarkAura, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
			this.Timer += Time.deltaTime;
		}
		if (this.Yandere.transform.position.y > (float)1000)
		{
			this.DemonRealmAudio.volume = Mathf.MoveTowards(this.DemonRealmAudio.volume, 0.5f, Time.deltaTime * 0.1f);
		}
		else
		{
			this.DemonRealmAudio.volume = Mathf.MoveTowards(this.DemonRealmAudio.volume, (float)0, Time.deltaTime * 0.1f);
		}
		if (this.Timer > (float)0)
		{
			if (this.Yandere.transform.position.y > (float)1000)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)4)
				{
					float a = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
					Color color = this.Darkness.color;
					float num = color.a = a;
					Color color2 = this.Darkness.color = color;
					if (this.Darkness.color.a == (float)1)
					{
						this.Yandere.transform.position = new Vector3((float)12, (float)0, (float)28);
						this.Yandere.Character.active = true;
						this.Yandere.SetAnimationLayers();
						this.HeartbeatCamera.active = true;
						this.FPS.active = true;
						this.HUD.active = true;
					}
				}
				else if (this.Timer > (float)1)
				{
					this.Yandere.Character.active = false;
				}
			}
			else
			{
				this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0.5f, Time.deltaTime * 0.5f);
				if (this.Jukebox.Volume == 0.5f)
				{
					float a2 = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
					Color color3 = this.Darkness.color;
					float num2 = color3.a = a2;
					Color color4 = this.Darkness.color = color3;
					if (this.Darkness.color.a == (float)0)
					{
						this.Darkness.enabled = false;
						this.Yandere.CanMove = true;
						this.Clock.StopTime = false;
						this.Timer = (float)0;
					}
				}
			}
		}
	}

	// Token: 0x06000300 RID: 768 RVA: 0x0003DF88 File Offset: 0x0003C188
	public virtual void Main()
	{
	}

	// Token: 0x04000790 RID: 1936
	public YandereScript Yandere;

	// Token: 0x04000791 RID: 1937
	public JukeboxScript Jukebox;

	// Token: 0x04000792 RID: 1938
	public PromptScript Prompt;

	// Token: 0x04000793 RID: 1939
	public ClockScript Clock;

	// Token: 0x04000794 RID: 1940
	public AudioSource DemonRealmAudio;

	// Token: 0x04000795 RID: 1941
	public GameObject HeartbeatCamera;

	// Token: 0x04000796 RID: 1942
	public GameObject DarkAura;

	// Token: 0x04000797 RID: 1943
	public GameObject FPS;

	// Token: 0x04000798 RID: 1944
	public GameObject HUD;

	// Token: 0x04000799 RID: 1945
	public UISprite Darkness;

	// Token: 0x0400079A RID: 1946
	public float Timer;
}
