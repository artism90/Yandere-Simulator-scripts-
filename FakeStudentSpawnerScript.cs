using System;
using UnityEngine;

// Token: 0x02000090 RID: 144
[Serializable]
public class FakeStudentSpawnerScript : MonoBehaviour
{
	// Token: 0x0600035A RID: 858 RVA: 0x000465E4 File Offset: 0x000447E4
	public virtual void Spawn()
	{
		if (!this.AlreadySpawned)
		{
			this.Student = this.FakeFemale;
			this.NESW = 1;
			while (this.Spawned < this.FloorLimit * 3)
			{
				if (this.NESW == 1)
				{
					this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.Student, new Vector3(UnityEngine.Random.Range(-21f, 21f), (float)this.Height, UnityEngine.Random.Range(21f, 19f)), Quaternion.identity);
				}
				else if (this.NESW == 2)
				{
					this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.Student, new Vector3(UnityEngine.Random.Range(19f, 21f), (float)this.Height, UnityEngine.Random.Range(29f, -37f)), Quaternion.identity);
				}
				else if (this.NESW == 3)
				{
					this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.Student, new Vector3(UnityEngine.Random.Range(-21f, 21f), (float)this.Height, UnityEngine.Random.Range(-21f, -19f)), Quaternion.identity);
				}
				else if (this.NESW == 4)
				{
					this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.Student, new Vector3(UnityEngine.Random.Range(-19f, -21f), (float)this.Height, UnityEngine.Random.Range(29f, -37f)), Quaternion.identity);
				}
				((PlaceholderStudentScript)this.NewStudent.GetComponent(typeof(PlaceholderStudentScript))).NESW = this.NESW;
				this.NewStudent.transform.parent = this.FakeStudentParent;
				this.CurrentFloor++;
				this.CurrentRow++;
				this.Spawned++;
				if (this.CurrentFloor == this.FloorLimit)
				{
					this.CurrentFloor = 0;
					this.Height += 4;
				}
				if (this.CurrentRow == this.RowLimit)
				{
					this.CurrentRow = 0;
					this.NESW++;
					if (this.NESW > 4)
					{
						this.NESW = 1;
					}
				}
				if (this.Student == this.FakeFemale)
				{
					this.Student = this.FakeMale;
				}
				else
				{
					this.Student = this.FakeFemale;
				}
			}
			this.AlreadySpawned = true;
		}
		else if (this.FakeStudentParent.active)
		{
			this.FakeStudentParent.active = false;
		}
		else
		{
			this.FakeStudentParent.active = true;
		}
	}

	// Token: 0x0600035B RID: 859 RVA: 0x000468AC File Offset: 0x00044AAC
	public virtual void Main()
	{
	}

	// Token: 0x0400086F RID: 2159
	public Transform FakeStudentParent;

	// Token: 0x04000870 RID: 2160
	public GameObject NewStudent;

	// Token: 0x04000871 RID: 2161
	public GameObject FakeFemale;

	// Token: 0x04000872 RID: 2162
	public GameObject FakeMale;

	// Token: 0x04000873 RID: 2163
	public GameObject Student;

	// Token: 0x04000874 RID: 2164
	public bool AlreadySpawned;

	// Token: 0x04000875 RID: 2165
	public int CurrentFloor;

	// Token: 0x04000876 RID: 2166
	public int CurrentRow;

	// Token: 0x04000877 RID: 2167
	public int FloorLimit;

	// Token: 0x04000878 RID: 2168
	public int RowLimit;

	// Token: 0x04000879 RID: 2169
	public int Spawned;

	// Token: 0x0400087A RID: 2170
	public int Height;

	// Token: 0x0400087B RID: 2171
	public int NESW;
}
