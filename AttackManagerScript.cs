using System;
using UnityEngine;

// Token: 0x02000043 RID: 67
[Serializable]
public class AttackManagerScript : MonoBehaviour
{
	// Token: 0x060001DE RID: 478 RVA: 0x00022EB0 File Offset: 0x000210B0
	public AttackManagerScript()
	{
		this.VictimAnimName = string.Empty;
		this.AnimName = string.Empty;
		this.Gender = string.Empty;
		this.Prefix = string.Empty;
		this.Sanity = string.Empty;
		this.CurrentWeapon = 1;
	}

	// Token: 0x060001DF RID: 479 RVA: 0x00022F04 File Offset: 0x00021104
	public virtual void Attack()
	{
		this.Weapon = this.Yandere.Weapon[this.Yandere.Equipped];
		this.Yandere.FollowHips = true;
		this.AttackTimer = (float)0;
		this.EffectPhase = 0;
		this.SanityCheck();
		if (this.Weapon.Type == 1)
		{
			this.Prefix = "knife";
		}
		else if (this.Weapon.Type == 2)
		{
			this.Prefix = "katana";
		}
		else if (this.Weapon.Type == 3)
		{
			this.Prefix = "bat";
		}
		else if (this.Weapon.Type == 4)
		{
			this.Prefix = "saw";
		}
		if (!this.Yandere.TargetStudent.Male)
		{
			this.Gender = "f02_";
		}
		else
		{
			this.Gender = string.Empty;
		}
		if (!this.Stealth)
		{
			this.AnimName = "f02_" + this.Prefix + this.Sanity + "SanityA_00";
			this.VictimAnimName = this.Gender + this.Prefix + this.Sanity + "SanityB_00";
		}
		else
		{
			this.AnimName = "f02_" + this.Prefix + "StealthA_00";
			this.VictimAnimName = this.Gender + this.Prefix + "StealthB_00";
		}
		this.Yandere.Character.animation[this.AnimName].time = (float)0;
		this.Yandere.Character.animation.CrossFade(this.AnimName);
		this.Victim.animation[this.VictimAnimName].time = (float)0;
		this.Victim.animation.CrossFade(this.VictimAnimName);
		if (this.Stealth)
		{
			this.Weapon.gameObject.audio.clip = this.Weapon.Clips[0];
		}
		else if (this.Yandere.Sanity / (float)100 > 0.6666667f)
		{
			this.Weapon.gameObject.audio.clip = this.Weapon.Clips[1];
		}
		else if (this.Yandere.Sanity / (float)100 > 0.333333343f)
		{
			this.Weapon.gameObject.audio.clip = this.Weapon.Clips[2];
		}
		else
		{
			this.Weapon.gameObject.audio.clip = this.Weapon.Clips[3];
		}
		this.Weapon.gameObject.audio.time = (float)0;
		this.Weapon.gameObject.audio.Play();
		if (this.Weapon.Type == 1)
		{
			this.Weapon.Flip = true;
		}
		this.GetDistance();
		this.Attacking = true;
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x00023244 File Offset: 0x00021444
	public virtual void Update()
	{
		if (this.Attacking)
		{
			this.AttackTimer += Time.deltaTime;
			this.SpecialEffect();
			if (this.Yandere.Sanity <= (float)0 && !this.Yandere.Chased)
			{
				this.LoopCheck();
			}
			this.SpecialEffect();
			if (this.Yandere.Character.animation[this.AnimName].time > this.Yandere.Character.animation[this.AnimName].length - 0.33333f)
			{
				this.Yandere.Character.animation.CrossFade("f02_idle_00");
				this.Weapon.Flip = false;
			}
			if (this.AttackTimer > this.Yandere.Character.animation[this.AnimName].length)
			{
				if (this.Yandere.TargetStudent == this.Yandere.StudentManager.Reporter)
				{
					this.Yandere.StudentManager.Reporter = null;
				}
				this.Yandere.TargetStudent.DeathCause = this.Yandere.Weapon[this.Yandere.Equipped].WeaponID;
				this.Yandere.TargetStudent.BecomeRagdoll();
				this.Yandere.TargetStudent.Dead = true;
				this.Yandere.Sanity = this.Yandere.Sanity - (float)20 * this.Yandere.Numbness;
				this.Yandere.UpdateSanity();
				this.Yandere.Bloodiness = this.Yandere.Bloodiness + (float)20;
				this.Yandere.UpdateBlood();
				this.Yandere.StainWeapon();
				this.Yandere.Attacking = false;
				this.Yandere.FollowHips = false;
				this.Yandere.MyController.radius = 0.2f;
				this.Attacking = false;
				this.Stealth = false;
				this.EffectPhase = 0;
				this.AttackTimer = (float)0;
				this.Timer = (float)0;
				this.CheckForSpecialCase();
				if (!this.Yandere.Noticed)
				{
					this.Yandere.CanMove = true;
				}
				else
				{
					this.Yandere.Weapon[this.Yandere.Equipped].Drop();
				}
			}
		}
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x000234B8 File Offset: 0x000216B8
	public virtual void SanityCheck()
	{
		if (this.Yandere.Sanity > (float)100)
		{
			this.Yandere.Sanity = (float)100;
		}
		else if (this.Yandere.Sanity < (float)0)
		{
			this.Yandere.Sanity = (float)0;
		}
		if (this.Yandere.Sanity / (float)100 > 0.6666667f)
		{
			this.Sanity = "High";
		}
		else if (this.Yandere.Sanity / (float)100 > 0.333333343f)
		{
			this.Sanity = "Med";
		}
		else
		{
			this.Sanity = "Low";
		}
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x00023568 File Offset: 0x00021768
	public virtual void GetDistance()
	{
		if (this.Weapon.Type == 1)
		{
			if (this.Stealth)
			{
				this.Distance = 0.75f;
			}
			else if (this.Yandere.Sanity / (float)100 > 0.6666667f)
			{
				this.Distance = (float)1;
			}
			else if (this.Yandere.Sanity / (float)100 > 0.333333343f)
			{
				this.Distance = 0.75f;
			}
			else
			{
				this.Distance = 0.5f;
			}
		}
		else if (this.Weapon.Type == 2)
		{
			if (this.Stealth)
			{
				this.Distance = 0.5f;
			}
			else
			{
				this.Distance = (float)1;
			}
		}
		else if (this.Weapon.Type == 3)
		{
			if (this.Stealth)
			{
				this.Distance = 0.5f;
			}
			else if (this.Yandere.Sanity / (float)100 > 0.6666667f)
			{
				this.Distance = 0.75f;
			}
			else if (this.Yandere.Sanity / (float)100 > 0.333333343f)
			{
				this.Distance = (float)1;
			}
			else
			{
				this.Distance = (float)1;
			}
		}
		else if (this.Weapon.Type == 4)
		{
			if (this.Stealth)
			{
				this.Distance = 0.7f;
			}
			else
			{
				this.Distance = (float)1;
			}
		}
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x000236FC File Offset: 0x000218FC
	public virtual void SpecialEffect()
	{
		if (this.Weapon.Type == 1)
		{
			if (!this.Stealth)
			{
				if (this.Yandere.Sanity / (float)100 > 0.6666667f)
				{
					if (this.EffectPhase == 0 && this.Yandere.Character.animation[this.AnimName].time > 1.06666672f)
					{
						UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.Yandere.Sanity / (float)100 > 0.333333343f)
				{
					if (this.EffectPhase == 0)
					{
						if (this.Yandere.Character.animation[this.AnimName].time > 2.16666675f)
						{
							UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.1f, Quaternion.identity);
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 1 && this.Yandere.Character.animation[this.AnimName].time > 3.0333333f)
					{
						UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 0)
				{
					if (this.Yandere.Character.animation[this.AnimName].time > 2.76666665f)
					{
						UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 1)
				{
					if (this.Yandere.Character.animation[this.AnimName].time > 3.5333333f)
					{
						UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.1f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 2 && this.Yandere.Character.animation[this.AnimName].time > 4.16666651f)
				{
					UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.1f, Quaternion.identity);
					this.EffectPhase++;
				}
			}
			else if (this.EffectPhase == 0 && this.Yandere.Character.animation[this.AnimName].time > 0.966666639f)
			{
				UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.1f, Quaternion.identity);
				this.EffectPhase++;
			}
		}
		else if (this.Weapon.Type == 2)
		{
			if (!this.Stealth)
			{
				if (this.Yandere.Sanity / (float)100 > 0.6666667f)
				{
					if (this.EffectPhase == 0 && this.Yandere.Character.animation[this.AnimName].time > 0.483333319f)
					{
						UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.Yandere.Sanity / (float)100 > 0.333333343f)
				{
					if (this.EffectPhase == 0)
					{
						if (this.Yandere.Character.animation[this.AnimName].time > 0.55f)
						{
							UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 1 && this.Yandere.Character.animation[this.AnimName].time > 1.51666665f)
					{
						UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 0)
				{
					if (this.Yandere.Character.animation[this.AnimName].time > 0.5f)
					{
						UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.66666f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 1)
				{
					if (this.Yandere.Character.animation[this.AnimName].time > 1f)
					{
						this.Weapon.transform.localEulerAngles = new Vector3((float)0, (float)180, (float)0);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 2)
				{
					if (this.Yandere.Character.animation[this.AnimName].time > 2.33333325f)
					{
						UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.66666f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 3)
				{
					if (this.Yandere.Character.animation[this.AnimName].time > 2.73333335f)
					{
						UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.66666f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 4)
				{
					if (this.Yandere.Character.animation[this.AnimName].time > 3.13333344f)
					{
						UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.66666f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 5)
				{
					if (this.Yandere.Character.animation[this.AnimName].time > 3.5333333f)
					{
						UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.66666f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 6)
				{
					if (this.Yandere.Character.animation[this.AnimName].time > 4.133333f)
					{
						UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.66666f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 8 && this.Yandere.Character.animation[this.AnimName].time > 5f)
				{
					this.Weapon.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
					this.EffectPhase++;
				}
			}
			else if (this.EffectPhase == 0)
			{
				if (this.Yandere.Character.animation[this.AnimName].time > 0.366666675f)
				{
					UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.66666f, Quaternion.identity);
					this.EffectPhase++;
				}
			}
			else if (this.EffectPhase == 1 && this.Yandere.Character.animation[this.AnimName].time > 1f)
			{
				UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.33333f, Quaternion.identity);
				this.EffectPhase++;
			}
		}
		else if (this.Weapon.Type == 3)
		{
			if (!this.Stealth)
			{
				if (this.Yandere.Sanity / (float)100 > 0.6666667f)
				{
					if (this.EffectPhase == 0 && this.Yandere.Character.animation[this.AnimName].time > 0.733333349f)
					{
						UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.Yandere.Sanity / (float)100 > 0.333333343f)
				{
					if (this.EffectPhase == 0)
					{
						if (this.Yandere.Character.animation[this.AnimName].time > 1f)
						{
							UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 1 && this.Yandere.Character.animation[this.AnimName].time > 2.9666667f)
					{
						UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 0)
				{
					if (this.Yandere.Character.animation[this.AnimName].time > 0.7f)
					{
						UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 1)
				{
					if (this.Yandere.Character.animation[this.AnimName].time > 3.1f)
					{
						UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 2)
				{
					if (this.Yandere.Character.animation[this.AnimName].time > 3.76666665f)
					{
						UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 3 && this.Yandere.Character.animation[this.AnimName].time > 4.4f)
				{
					UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.forward * 0.5f, Quaternion.identity);
					this.EffectPhase++;
				}
			}
		}
		else if (this.Weapon.Type == 4)
		{
			if (!this.Stealth)
			{
				if (this.Yandere.Sanity / (float)100 > 0.6666667f)
				{
					if (this.EffectPhase == 0)
					{
						if (this.Yandere.Character.animation[this.AnimName].time > (float)0)
						{
							this.Weapon.Spin = true;
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 1)
					{
						if (this.Yandere.Character.animation[this.AnimName].time > 0.733333349f)
						{
							this.Weapon.BloodSpray[0].Play();
							this.Weapon.BloodSpray[1].Play();
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 2 && this.Yandere.Character.animation[this.AnimName].time > 1.43333328f)
					{
						this.Weapon.Spin = false;
						this.Weapon.BloodSpray[0].Stop();
						this.Weapon.BloodSpray[1].Stop();
						this.EffectPhase++;
					}
				}
				else if (this.Yandere.Sanity / (float)100 > 0.333333343f)
				{
					if (this.EffectPhase == 0)
					{
						if (this.Yandere.Character.animation[this.AnimName].time > (float)0)
						{
							this.Weapon.Spin = true;
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 1)
					{
						if (this.Yandere.Character.animation[this.AnimName].time > 1.1f)
						{
							this.Weapon.BloodSpray[0].Play();
							this.Weapon.BloodSpray[1].Play();
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 2)
					{
						if (this.Yandere.Character.animation[this.AnimName].time > 1.43333328f)
						{
							this.Weapon.BloodSpray[0].Stop();
							this.Weapon.BloodSpray[1].Stop();
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 3)
					{
						if (this.Yandere.Character.animation[this.AnimName].time > 2.36666656f)
						{
							this.Weapon.BloodSpray[0].Play();
							this.Weapon.BloodSpray[1].Play();
							this.EffectPhase++;
						}
					}
					else if (this.EffectPhase == 4 && this.Yandere.Character.animation[this.AnimName].time > 2.4f)
					{
						this.Weapon.Spin = true;
						this.Weapon.BloodSpray[0].Stop();
						this.Weapon.BloodSpray[1].Stop();
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 0)
				{
					if (this.Yandere.Character.animation[this.AnimName].time > (float)0)
					{
						this.Weapon.Spin = true;
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 1)
				{
					if (this.Yandere.Character.animation[this.AnimName].time > 0.6666667f)
					{
						this.Weapon.BloodSpray[0].Play();
						this.Weapon.BloodSpray[1].Play();
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 2)
				{
					if (this.Yandere.Character.animation[this.AnimName].time > 0.733333349f)
					{
						this.Weapon.BloodSpray[0].Stop();
						this.Weapon.BloodSpray[1].Stop();
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 3)
				{
					if (this.Yandere.Character.animation[this.AnimName].time > 3f)
					{
						this.Weapon.BloodSpray[0].Play();
						this.Weapon.BloodSpray[1].Play();
						this.EffectPhase++;
					}
				}
				else if (this.EffectPhase == 4 && this.Yandere.Character.animation[this.AnimName].time > 4.866667f)
				{
					this.Weapon.Spin = false;
					this.Weapon.BloodSpray[0].Stop();
					this.Weapon.BloodSpray[1].Stop();
					this.EffectPhase++;
				}
			}
			else if (this.EffectPhase == 0 && this.Yandere.Character.animation[this.AnimName].time > 1f)
			{
				UnityEngine.Object.Instantiate(this.BloodEffect, this.Weapon.transform.position + this.Weapon.transform.right * 0.2f + this.Weapon.transform.forward * -0.066666f, Quaternion.identity);
				this.EffectPhase++;
			}
		}
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x00024C64 File Offset: 0x00022E64
	public virtual void LoopCheck()
	{
		if (Input.GetButtonDown("X"))
		{
			if (this.Weapon.Type == 1)
			{
				if (this.Yandere.Character.animation[this.AnimName].time > 3.5333333f && this.Yandere.Character.animation[this.AnimName].time < 4.16666651f)
				{
					this.LoopStart = 106f;
					this.LoopEnd = 125f;
					this.LoopPhase = 2;
					this.Loop = true;
				}
			}
			else if (this.Weapon.Type == 2)
			{
				if (this.Yandere.Character.animation[this.AnimName].time > 3.36666656f && this.Yandere.Character.animation[this.AnimName].time < 3.9f)
				{
					this.LoopStart = 101f;
					this.LoopEnd = 117f;
					this.LoopPhase = 5;
					this.Loop = true;
				}
			}
			else if (this.Weapon.Type == 3)
			{
				if (this.Yandere.Character.animation[this.AnimName].time > 3.76666665f && this.Yandere.Character.animation[this.AnimName].time < 4.4f)
				{
					this.LoopStart = 113f;
					this.LoopEnd = 132f;
					this.LoopPhase = 2;
					this.Loop = true;
				}
			}
			else if (this.Weapon.Type == 4 && this.Yandere.Character.animation[this.AnimName].time > 3.0333333f && this.Yandere.Character.animation[this.AnimName].time < 4.5666666f)
			{
				this.LoopStart = 91f;
				this.LoopEnd = 137f;
				this.LoopPhase = 3;
				this.PingPong = true;
			}
		}
		if (this.PingPong)
		{
			if (this.Yandere.Character.animation[this.AnimName].time > this.LoopEnd / 30f)
			{
				this.Weapon.gameObject.audio.pitch = (float)1 + UnityEngine.Random.Range(0.1f, -0.1f);
				this.Weapon.gameObject.audio.time = this.LoopStart / 30f;
				this.Victim.animation[this.VictimAnimName].speed = (float)-1;
				this.Yandere.Character.animation[this.AnimName].speed = (float)-1;
				this.EffectPhase = this.LoopPhase;
				this.AttackTimer = (float)0;
			}
			else if (this.Yandere.Character.animation[this.AnimName].time < this.LoopStart / 30f)
			{
				this.Weapon.gameObject.audio.pitch = (float)1 + UnityEngine.Random.Range(0.1f, -0.1f);
				this.Weapon.gameObject.audio.time = this.LoopStart / 30f;
				this.Victim.animation[this.VictimAnimName].speed = (float)1;
				this.Yandere.Character.animation[this.AnimName].speed = (float)1;
				this.EffectPhase = this.LoopPhase;
				this.AttackTimer = this.LoopStart / 30f;
				this.EffectPhase = this.LoopPhase;
				this.PingPong = false;
			}
		}
		if (this.Loop && this.Yandere.Character.animation[this.AnimName].time > this.LoopEnd / 30f)
		{
			this.Weapon.gameObject.audio.pitch = (float)1 + UnityEngine.Random.Range(0.1f, -0.1f);
			this.Weapon.gameObject.audio.time = this.LoopStart / 30f;
			this.Victim.animation[this.VictimAnimName].time = this.LoopStart / 30f;
			this.Yandere.Character.animation[this.AnimName].time = this.LoopStart / 30f;
			this.AttackTimer = this.LoopStart / 30f;
			this.EffectPhase = this.LoopPhase;
			this.Loop = false;
		}
	}

	// Token: 0x060001E5 RID: 485 RVA: 0x00025178 File Offset: 0x00023378
	public virtual void CheckForSpecialCase()
	{
		if (this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 8)
		{
			this.Yandere.TargetStudent.Ragdoll.Sacrifice = true;
			if (PlayerPrefs.GetInt("Paranormal") == 1)
			{
				this.Yandere.Weapon[this.Yandere.Equipped].Effect();
			}
		}
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x000251EC File Offset: 0x000233EC
	public virtual void Main()
	{
	}

	// Token: 0x04000408 RID: 1032
	public GameObject BloodEffect;

	// Token: 0x04000409 RID: 1033
	public GameObject Victim;

	// Token: 0x0400040A RID: 1034
	public YandereScript Yandere;

	// Token: 0x0400040B RID: 1035
	public WeaponScript Weapon;

	// Token: 0x0400040C RID: 1036
	public string VictimAnimName;

	// Token: 0x0400040D RID: 1037
	public string AnimName;

	// Token: 0x0400040E RID: 1038
	public string Gender;

	// Token: 0x0400040F RID: 1039
	public string Prefix;

	// Token: 0x04000410 RID: 1040
	public string Sanity;

	// Token: 0x04000411 RID: 1041
	public bool Attacking;

	// Token: 0x04000412 RID: 1042
	public bool PingPong;

	// Token: 0x04000413 RID: 1043
	public bool Stealth;

	// Token: 0x04000414 RID: 1044
	public bool Loop;

	// Token: 0x04000415 RID: 1045
	public int CurrentWeapon;

	// Token: 0x04000416 RID: 1046
	public int EffectPhase;

	// Token: 0x04000417 RID: 1047
	public int LoopPhase;

	// Token: 0x04000418 RID: 1048
	public float AttackTimer;

	// Token: 0x04000419 RID: 1049
	public float Distance;

	// Token: 0x0400041A RID: 1050
	public float Timer;

	// Token: 0x0400041B RID: 1051
	public float LoopStart;

	// Token: 0x0400041C RID: 1052
	public float LoopEnd;
}
