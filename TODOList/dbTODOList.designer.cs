﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TODOList
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TODOList")]
	public partial class dbTODOListDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTask(Task instance);
    partial void UpdateTask(Task instance);
    partial void DeleteTask(Task instance);
    partial void InsertTaskTag(TaskTag instance);
    partial void UpdateTaskTag(TaskTag instance);
    partial void DeleteTaskTag(TaskTag instance);
    partial void InsertTag(Tag instance);
    partial void UpdateTag(Tag instance);
    partial void DeleteTag(Tag instance);
    partial void InsertPriority(Priority instance);
    partial void UpdatePriority(Priority instance);
    partial void DeletePriority(Priority instance);
    partial void InsertAssignee(Assignee instance);
    partial void UpdateAssignee(Assignee instance);
    partial void DeleteAssignee(Assignee instance);
    partial void InsertState(State instance);
    partial void UpdateState(State instance);
    partial void DeleteState(State instance);
    #endregion
		
		public dbTODOListDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["TODOListConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbTODOListDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbTODOListDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbTODOListDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbTODOListDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Task> Tasks
		{
			get
			{
				return this.GetTable<Task>();
			}
		}
		
		public System.Data.Linq.Table<TaskTag> TaskTags
		{
			get
			{
				return this.GetTable<TaskTag>();
			}
		}
		
		public System.Data.Linq.Table<Tag> Tags
		{
			get
			{
				return this.GetTable<Tag>();
			}
		}
		
		public System.Data.Linq.Table<Priority> Priorities
		{
			get
			{
				return this.GetTable<Priority>();
			}
		}
		
		public System.Data.Linq.Table<Assignee> Assignees
		{
			get
			{
				return this.GetTable<Assignee>();
			}
		}
		
		public System.Data.Linq.Table<State> States
		{
			get
			{
				return this.GetTable<State>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Tasks")]
	public partial class Task : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _TaskId;
		
		private System.DateTime _StartDate;
		
		private System.Nullable<System.DateTime> _FinishDate;
		
		private string _Title;
		
		private string _Description;
		
		private System.Guid _PriorityId;
		
		private System.Guid _AssigneeId;
		
		private string _Picture;
		
		private System.Guid _StateId;
		
		private EntitySet<TaskTag> _TaskTags;
		
		private EntityRef<Priority> _Priority;
		
		private EntityRef<Assignee> _Assignee;
		
		private EntityRef<State> _State;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTaskIdChanging(System.Guid value);
    partial void OnTaskIdChanged();
    partial void OnStartDateChanging(System.DateTime value);
    partial void OnStartDateChanged();
    partial void OnFinishDateChanging(System.Nullable<System.DateTime> value);
    partial void OnFinishDateChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnPriorityIdChanging(System.Guid value);
    partial void OnPriorityIdChanged();
    partial void OnAssigneeIdChanging(System.Guid value);
    partial void OnAssigneeIdChanged();
    partial void OnPictureChanging(string value);
    partial void OnPictureChanged();
    partial void OnStateIdChanging(System.Guid value);
    partial void OnStateIdChanged();
    #endregion
		
		public Task()
		{
			this._TaskTags = new EntitySet<TaskTag>(new Action<TaskTag>(this.attach_TaskTags), new Action<TaskTag>(this.detach_TaskTags));
			this._Priority = default(EntityRef<Priority>);
			this._Assignee = default(EntityRef<Assignee>);
			this._State = default(EntityRef<State>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaskId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid TaskId
		{
			get
			{
				return this._TaskId;
			}
			set
			{
				if ((this._TaskId != value))
				{
					this.OnTaskIdChanging(value);
					this.SendPropertyChanging();
					this._TaskId = value;
					this.SendPropertyChanged("TaskId");
					this.OnTaskIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StartDate", DbType="DateTime NOT NULL")]
		public System.DateTime StartDate
		{
			get
			{
				return this._StartDate;
			}
			set
			{
				if ((this._StartDate != value))
				{
					this.OnStartDateChanging(value);
					this.SendPropertyChanging();
					this._StartDate = value;
					this.SendPropertyChanged("StartDate");
					this.OnStartDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FinishDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> FinishDate
		{
			get
			{
				return this._FinishDate;
			}
			set
			{
				if ((this._FinishDate != value))
				{
					this.OnFinishDateChanging(value);
					this.SendPropertyChanging();
					this._FinishDate = value;
					this.SendPropertyChanged("FinishDate");
					this.OnFinishDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PriorityId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid PriorityId
		{
			get
			{
				return this._PriorityId;
			}
			set
			{
				if ((this._PriorityId != value))
				{
					if (this._Priority.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPriorityIdChanging(value);
					this.SendPropertyChanging();
					this._PriorityId = value;
					this.SendPropertyChanged("PriorityId");
					this.OnPriorityIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AssigneeId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid AssigneeId
		{
			get
			{
				return this._AssigneeId;
			}
			set
			{
				if ((this._AssigneeId != value))
				{
					if (this._Assignee.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnAssigneeIdChanging(value);
					this.SendPropertyChanging();
					this._AssigneeId = value;
					this.SendPropertyChanged("AssigneeId");
					this.OnAssigneeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Picture", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string Picture
		{
			get
			{
				return this._Picture;
			}
			set
			{
				if ((this._Picture != value))
				{
					this.OnPictureChanging(value);
					this.SendPropertyChanging();
					this._Picture = value;
					this.SendPropertyChanged("Picture");
					this.OnPictureChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StateId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid StateId
		{
			get
			{
				return this._StateId;
			}
			set
			{
				if ((this._StateId != value))
				{
					if (this._State.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnStateIdChanging(value);
					this.SendPropertyChanging();
					this._StateId = value;
					this.SendPropertyChanged("StateId");
					this.OnStateIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Task_TaskTag", Storage="_TaskTags", ThisKey="TaskId", OtherKey="TaskId")]
		public EntitySet<TaskTag> TaskTags
		{
			get
			{
				return this._TaskTags;
			}
			set
			{
				this._TaskTags.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Priority_Task", Storage="_Priority", ThisKey="PriorityId", OtherKey="PriorityId", IsForeignKey=true)]
		public Priority Priority
		{
			get
			{
				return this._Priority.Entity;
			}
			set
			{
				Priority previousValue = this._Priority.Entity;
				if (((previousValue != value) 
							|| (this._Priority.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Priority.Entity = null;
						previousValue.Tasks.Remove(this);
					}
					this._Priority.Entity = value;
					if ((value != null))
					{
						value.Tasks.Add(this);
						this._PriorityId = value.PriorityId;
					}
					else
					{
						this._PriorityId = default(System.Guid);
					}
					this.SendPropertyChanged("Priority");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Assignee_Task", Storage="_Assignee", ThisKey="AssigneeId", OtherKey="AssigneeId", IsForeignKey=true)]
		public Assignee Assignee
		{
			get
			{
				return this._Assignee.Entity;
			}
			set
			{
				Assignee previousValue = this._Assignee.Entity;
				if (((previousValue != value) 
							|| (this._Assignee.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Assignee.Entity = null;
						previousValue.Tasks.Remove(this);
					}
					this._Assignee.Entity = value;
					if ((value != null))
					{
						value.Tasks.Add(this);
						this._AssigneeId = value.AssigneeId;
					}
					else
					{
						this._AssigneeId = default(System.Guid);
					}
					this.SendPropertyChanged("Assignee");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="State_Task", Storage="_State", ThisKey="StateId", OtherKey="StateId", IsForeignKey=true)]
		public State State
		{
			get
			{
				return this._State.Entity;
			}
			set
			{
				State previousValue = this._State.Entity;
				if (((previousValue != value) 
							|| (this._State.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._State.Entity = null;
						previousValue.Tasks.Remove(this);
					}
					this._State.Entity = value;
					if ((value != null))
					{
						value.Tasks.Add(this);
						this._StateId = value.StateId;
					}
					else
					{
						this._StateId = default(System.Guid);
					}
					this.SendPropertyChanged("State");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_TaskTags(TaskTag entity)
		{
			this.SendPropertyChanging();
			entity.Task = this;
		}
		
		private void detach_TaskTags(TaskTag entity)
		{
			this.SendPropertyChanging();
			entity.Task = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TaskTags")]
	public partial class TaskTag : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _TaskTagId;
		
		private System.Guid _TaskId;
		
		private System.Guid _TagId;
		
		private EntityRef<Task> _Task;
		
		private EntityRef<Tag> _Tag;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTaskTagIdChanging(System.Guid value);
    partial void OnTaskTagIdChanged();
    partial void OnTaskIdChanging(System.Guid value);
    partial void OnTaskIdChanged();
    partial void OnTagIdChanging(System.Guid value);
    partial void OnTagIdChanged();
    #endregion
		
		public TaskTag()
		{
			this._Task = default(EntityRef<Task>);
			this._Tag = default(EntityRef<Tag>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaskTagId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid TaskTagId
		{
			get
			{
				return this._TaskTagId;
			}
			set
			{
				if ((this._TaskTagId != value))
				{
					this.OnTaskTagIdChanging(value);
					this.SendPropertyChanging();
					this._TaskTagId = value;
					this.SendPropertyChanged("TaskTagId");
					this.OnTaskTagIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaskId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid TaskId
		{
			get
			{
				return this._TaskId;
			}
			set
			{
				if ((this._TaskId != value))
				{
					if (this._Task.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnTaskIdChanging(value);
					this.SendPropertyChanging();
					this._TaskId = value;
					this.SendPropertyChanged("TaskId");
					this.OnTaskIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TagId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid TagId
		{
			get
			{
				return this._TagId;
			}
			set
			{
				if ((this._TagId != value))
				{
					if (this._Tag.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnTagIdChanging(value);
					this.SendPropertyChanging();
					this._TagId = value;
					this.SendPropertyChanged("TagId");
					this.OnTagIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Task_TaskTag", Storage="_Task", ThisKey="TaskId", OtherKey="TaskId", IsForeignKey=true)]
		public Task Task
		{
			get
			{
				return this._Task.Entity;
			}
			set
			{
				Task previousValue = this._Task.Entity;
				if (((previousValue != value) 
							|| (this._Task.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Task.Entity = null;
						previousValue.TaskTags.Remove(this);
					}
					this._Task.Entity = value;
					if ((value != null))
					{
						value.TaskTags.Add(this);
						this._TaskId = value.TaskId;
					}
					else
					{
						this._TaskId = default(System.Guid);
					}
					this.SendPropertyChanged("Task");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Tag_TaskTag", Storage="_Tag", ThisKey="TagId", OtherKey="TagId", IsForeignKey=true)]
		public Tag Tag
		{
			get
			{
				return this._Tag.Entity;
			}
			set
			{
				Tag previousValue = this._Tag.Entity;
				if (((previousValue != value) 
							|| (this._Tag.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Tag.Entity = null;
						previousValue.TaskTags.Remove(this);
					}
					this._Tag.Entity = value;
					if ((value != null))
					{
						value.TaskTags.Add(this);
						this._TagId = value.TagId;
					}
					else
					{
						this._TagId = default(System.Guid);
					}
					this.SendPropertyChanged("Tag");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Tags")]
	public partial class Tag : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _TagId;
		
		private string _Text;
		
		private EntitySet<TaskTag> _TaskTags;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTagIdChanging(System.Guid value);
    partial void OnTagIdChanged();
    partial void OnTextChanging(string value);
    partial void OnTextChanged();
    #endregion
		
		public Tag()
		{
			this._TaskTags = new EntitySet<TaskTag>(new Action<TaskTag>(this.attach_TaskTags), new Action<TaskTag>(this.detach_TaskTags));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TagId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid TagId
		{
			get
			{
				return this._TagId;
			}
			set
			{
				if ((this._TagId != value))
				{
					this.OnTagIdChanging(value);
					this.SendPropertyChanging();
					this._TagId = value;
					this.SendPropertyChanged("TagId");
					this.OnTagIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Text", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Text
		{
			get
			{
				return this._Text;
			}
			set
			{
				if ((this._Text != value))
				{
					this.OnTextChanging(value);
					this.SendPropertyChanging();
					this._Text = value;
					this.SendPropertyChanged("Text");
					this.OnTextChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Tag_TaskTag", Storage="_TaskTags", ThisKey="TagId", OtherKey="TagId")]
		public EntitySet<TaskTag> TaskTags
		{
			get
			{
				return this._TaskTags;
			}
			set
			{
				this._TaskTags.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_TaskTags(TaskTag entity)
		{
			this.SendPropertyChanging();
			entity.Tag = this;
		}
		
		private void detach_TaskTags(TaskTag entity)
		{
			this.SendPropertyChanging();
			entity.Tag = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Priorities")]
	public partial class Priority : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _PriorityId;
		
		private string _Text;
		
		private EntitySet<Task> _Tasks;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPriorityIdChanging(System.Guid value);
    partial void OnPriorityIdChanged();
    partial void OnTextChanging(string value);
    partial void OnTextChanged();
    #endregion
		
		public Priority()
		{
			this._Tasks = new EntitySet<Task>(new Action<Task>(this.attach_Tasks), new Action<Task>(this.detach_Tasks));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PriorityId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid PriorityId
		{
			get
			{
				return this._PriorityId;
			}
			set
			{
				if ((this._PriorityId != value))
				{
					this.OnPriorityIdChanging(value);
					this.SendPropertyChanging();
					this._PriorityId = value;
					this.SendPropertyChanged("PriorityId");
					this.OnPriorityIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Text", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Text
		{
			get
			{
				return this._Text;
			}
			set
			{
				if ((this._Text != value))
				{
					this.OnTextChanging(value);
					this.SendPropertyChanging();
					this._Text = value;
					this.SendPropertyChanged("Text");
					this.OnTextChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Priority_Task", Storage="_Tasks", ThisKey="PriorityId", OtherKey="PriorityId")]
		public EntitySet<Task> Tasks
		{
			get
			{
				return this._Tasks;
			}
			set
			{
				this._Tasks.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Tasks(Task entity)
		{
			this.SendPropertyChanging();
			entity.Priority = this;
		}
		
		private void detach_Tasks(Task entity)
		{
			this.SendPropertyChanging();
			entity.Priority = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Assignees")]
	public partial class Assignee : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _AssigneeId;
		
		private string _Login;
		
		private string _FirstName;
		
		private string _LastName;
		
		private EntitySet<Task> _Tasks;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAssigneeIdChanging(System.Guid value);
    partial void OnAssigneeIdChanged();
    partial void OnLoginChanging(string value);
    partial void OnLoginChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    #endregion
		
		public Assignee()
		{
			this._Tasks = new EntitySet<Task>(new Action<Task>(this.attach_Tasks), new Action<Task>(this.detach_Tasks));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AssigneeId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid AssigneeId
		{
			get
			{
				return this._AssigneeId;
			}
			set
			{
				if ((this._AssigneeId != value))
				{
					this.OnAssigneeIdChanging(value);
					this.SendPropertyChanging();
					this._AssigneeId = value;
					this.SendPropertyChanged("AssigneeId");
					this.OnAssigneeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Login", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Login
		{
			get
			{
				return this._Login;
			}
			set
			{
				if ((this._Login != value))
				{
					this.OnLoginChanging(value);
					this.SendPropertyChanging();
					this._Login = value;
					this.SendPropertyChanged("Login");
					this.OnLoginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Assignee_Task", Storage="_Tasks", ThisKey="AssigneeId", OtherKey="AssigneeId")]
		public EntitySet<Task> Tasks
		{
			get
			{
				return this._Tasks;
			}
			set
			{
				this._Tasks.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Tasks(Task entity)
		{
			this.SendPropertyChanging();
			entity.Assignee = this;
		}
		
		private void detach_Tasks(Task entity)
		{
			this.SendPropertyChanging();
			entity.Assignee = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.States")]
	public partial class State : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _StateId;
		
		private string _Text;
		
		private EntitySet<Task> _Tasks;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnStateIdChanging(System.Guid value);
    partial void OnStateIdChanged();
    partial void OnTextChanging(string value);
    partial void OnTextChanged();
    #endregion
		
		public State()
		{
			this._Tasks = new EntitySet<Task>(new Action<Task>(this.attach_Tasks), new Action<Task>(this.detach_Tasks));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StateId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid StateId
		{
			get
			{
				return this._StateId;
			}
			set
			{
				if ((this._StateId != value))
				{
					this.OnStateIdChanging(value);
					this.SendPropertyChanging();
					this._StateId = value;
					this.SendPropertyChanged("StateId");
					this.OnStateIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Text", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Text
		{
			get
			{
				return this._Text;
			}
			set
			{
				if ((this._Text != value))
				{
					this.OnTextChanging(value);
					this.SendPropertyChanging();
					this._Text = value;
					this.SendPropertyChanged("Text");
					this.OnTextChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="State_Task", Storage="_Tasks", ThisKey="StateId", OtherKey="StateId")]
		public EntitySet<Task> Tasks
		{
			get
			{
				return this._Tasks;
			}
			set
			{
				this._Tasks.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Tasks(Task entity)
		{
			this.SendPropertyChanging();
			entity.State = this;
		}
		
		private void detach_Tasks(Task entity)
		{
			this.SendPropertyChanging();
			entity.State = null;
		}
	}
}
#pragma warning restore 1591
