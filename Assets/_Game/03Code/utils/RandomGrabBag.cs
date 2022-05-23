using System.Collections.Generic;

#nullable enable
namespace ghostly.utils {
	public class RandomGrabBag<T> {

		private readonly T[] choices;

		private readonly List<int> choiceIndicies;

		public int numEntriesTotal { get { return choices.Length; } }

		/// Construct with these possible choices.
		public RandomGrabBag(T[] choices, int? seed = null, bool autoReset = false) {
			this.choices =  choices;
			this.autoReset = autoReset;
			random = seed.HasValue ? new System.Random(seed.Value) : new System.Random();
			choiceIndicies = new List<int>();
			for (int i = choices.Length - 1; i >= 0; i--) {
				choiceIndicies.Add(i);
			}
		}

		/// Reset to choose from all choices again.
		public void reset() {
			choiceIndicies.Clear();
			for (int i = choices.Length - 1; i >= 0; i--) {
				choiceIndicies.Add(i);
			}
		}

		/// <summary>
		/// Returns whether there are choices remaining.
		/// </summary>
		/// <returns>true if there are values left; else false.</returns>
		public bool hasChoicesLeft() {
			return 0 < choiceIndicies.Count;
		}

		/// <summary>
		/// Get one randomly chosen value (like picking a card from the deck).
		/// </summary>
		/// <returns>The chosen card.</returns>
		public T chooseOne() {
			if (0 >= choiceIndicies.Count) {
				if (autoReset) {
					reset();
				} else {
					throw new System.IndexOutOfRangeException("No choices left");
				}
			}

			var chosenIndexIndex = random.Next(0, choiceIndicies.Count);
			var chosenIndex = choiceIndicies[chosenIndexIndex];
			choiceIndicies.RemoveAt(chosenIndexIndex);
			return choices[chosenIndex];
		}
		
		private readonly bool autoReset;

		private readonly System.Random random;
	}
}
