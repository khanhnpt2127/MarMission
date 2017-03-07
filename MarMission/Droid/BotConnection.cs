using System;
namespace MarMissionA.Droid
{
	public class BotConnection
	{
		public class MessageListItem
		{
			public string Text { get; set; }
			public string Sender { get; set; }

			public MessageListItem(string text, string sender)
			{
				Text = text;
				Sender = sender;
			}


		}


	
			public DirectLineClient Client = new DirectLineClient("xyDbS9lXtjk.cwA.Sqs.uap6tAT5SwNGdUp_VMt4MFGamXphOKbuqYhmcNG25AI");
			public Conversation MainConversation;
			public ChannelAccount Account;

			public BotConnection(string accountName)
			{
				MainConversation = Client.Conversations.StartConversation();
				Account = new ChannelAccount { Id = accountName, Name = accountName };
			}

			public void SendMessage(string messages)
			{
				Activity activity = new Activity
				{
					From = Account,
					Text = messages,
					Type = ActivityTypes.Message
				};
			}

			public async Task GerMessageAsync(ObservableCollection<MessageListItem> collection)
			{
				string watermark = null;
				//Loop retrieval
				while (true)
				{
					Debug.WriteLine("Reading message every 3 seconds");
					//Get activities (messages) after the watermark
					var activitySet =
						await Client.Conversations.GetActivitiesAsync(MainConversation.ConversationId, watermark);
					//Set new watermark
					watermark = activitySet?.Watermark;
					//Loop through the activities and add them to the list
					foreach (Activity activity in activitySet.Activities)
					{
						if (activity.From.Name == "MarsBot")
						{
							collection.Add(new MessageListItem(activity.Text, activity.From.Name));
						}
					}

				}

				//Wait 3 seconds
				await Task.Delay(3000);
			}


	}
}
