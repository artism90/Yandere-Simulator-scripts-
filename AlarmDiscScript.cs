using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000038 RID: 56
[Serializable]
public class AlarmDiscScript : MonoBehaviour
{
	// Token: 0x060001B0 RID: 432 RVA: 0x00020334 File Offset: 0x0001E534
	public virtual void Start()
	{
		float x = this.transform.localScale.x * ((float)2 - PlayerPrefs.GetFloat("SchoolAtmosphere") * 0.01f);
		Vector3 localScale = this.transform.localScale;
		float num = localScale.x = x;
		Vector3 vector = this.transform.localScale = localScale;
		float x2 = this.transform.localScale.x;
		Vector3 localScale2 = this.transform.localScale;
		float num2 = localScale2.z = x2;
		Vector3 vector2 = this.transform.localScale = localScale2;
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x000203E0 File Offset: 0x0001E5E0
	public virtual void Update()
	{
		if (this.Frame > 0)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
		else if (!this.NoScream)
		{
			if (!this.Long)
			{
				if (!this.Male)
				{
					this.PlayClip(this.FemaleScreams[UnityEngine.Random.Range(0, Extensions.get_length(this.FemaleScreams))], this.transform.position);
				}
				else
				{
					this.PlayClip(this.MaleScreams[UnityEngine.Random.Range(0, Extensions.get_length(this.MaleScreams))], this.transform.position);
				}
			}
			else if (!this.Male)
			{
				this.PlayClip(this.LongFemaleScreams[UnityEngine.Random.Range(0, Extensions.get_length(this.LongFemaleScreams))], this.transform.position);
			}
			else
			{
				this.PlayClip(this.LongMaleScreams[UnityEngine.Random.Range(0, Extensions.get_length(this.LongMaleScreams))], this.transform.position);
			}
		}
		this.Frame++;
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x000204F8 File Offset: 0x0001E6F8
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Student = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
			if (this.Student != null)
			{
				if (!this.Radio)
				{
					if (this.Student != this.Originator && !this.Student.TurnOffRadio && !this.Student.Dead && !this.Student.Dying && !this.Student.Alarmed && !this.Student.Wet && !this.Student.Slave && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse)
					{
						this.Student.Character.animation.CrossFade(this.Student.IdleAnim);
						if (this.Originator != null)
						{
							if (this.Originator.WitnessedMurder)
							{
								this.Student.DistractionSpot = new Vector3(this.transform.position.x, this.Student.Yandere.transform.position.y, this.transform.position.z);
							}
							else if (this.Originator.Corpse == null)
							{
								this.Student.DistractionSpot = new Vector3(this.transform.position.x, this.Student.transform.position.y, this.transform.position.z);
							}
							else
							{
								this.Student.DistractionSpot = new Vector3(this.Originator.Corpse.transform.position.x, this.Student.transform.position.y, this.Originator.Corpse.transform.position.z);
							}
						}
						else
						{
							this.Student.DistractionSpot = new Vector3(this.transform.position.x, this.Student.transform.position.y, this.transform.position.z);
						}
						this.Student.DiscCheck = true;
						if (this.Shocking)
						{
							this.Student.Hesitation = 0.5f;
						}
						this.Student.Alarm = (float)200;
					}
				}
				else if (!this.Student.Male && !this.Student.Dead && !this.Student.Dying && !this.Student.Alarmed && !this.Student.Wet && !this.Student.Slave && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse && this.Student.CharacterAnimation != null && this.SourceRadio.Victim == null)
				{
					this.Student.CharacterAnimation.CrossFade(this.Student.IdleAnim);
					this.Student.Pathfinding.canSearch = false;
					this.Student.Pathfinding.canMove = false;
					this.Student.Radio = this.SourceRadio;
					this.Student.TurnOffRadio = true;
					this.Student.Routine = false;
					this.SourceRadio.Victim = this.Student;
				}
			}
		}
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x0002090C File Offset: 0x0001EB0C
	public virtual void PlayClip(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = (float)5;
		audioSource.maxDistance = (float)10;
		audioSource.volume = 0.5f;
		if (this.Student != null)
		{
			this.Student.DeathScream = gameObject;
		}
	}

	// Token: 0x060001B4 RID: 436 RVA: 0x000209A0 File Offset: 0x0001EBA0
	public virtual void Main()
	{
	}

	// Token: 0x0400039A RID: 922
	public AudioClip[] LongFemaleScreams;

	// Token: 0x0400039B RID: 923
	public AudioClip[] LongMaleScreams;

	// Token: 0x0400039C RID: 924
	public AudioClip[] FemaleScreams;

	// Token: 0x0400039D RID: 925
	public AudioClip[] MaleScreams;

	// Token: 0x0400039E RID: 926
	public StudentScript Originator;

	// Token: 0x0400039F RID: 927
	public RadioScript SourceRadio;

	// Token: 0x040003A0 RID: 928
	public StudentScript Student;

	// Token: 0x040003A1 RID: 929
	public bool NoScream;

	// Token: 0x040003A2 RID: 930
	public bool Shocking;

	// Token: 0x040003A3 RID: 931
	public bool Radio;

	// Token: 0x040003A4 RID: 932
	public bool Male;

	// Token: 0x040003A5 RID: 933
	public bool Long;

	// Token: 0x040003A6 RID: 934
	public int Frame;
}
