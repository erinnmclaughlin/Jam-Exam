using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace WebApp.Components
{
    public class CarouselItem
    {
        public int DisplayOrder { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
    }

    public partial class Carousel
    {
        [Inject] private NavigationManager Navigation { get; set; } = null!;

        [Parameter] public List<CarouselItem> Items { get; set; } = null!;

        private int Center { get; set; }

        protected override void OnParametersSet()
        {
            foreach (var item in Items)
                item.DisplayOrder = Items.IndexOf(item);

            Center = Items.Count / 2;
            base.OnParametersSet();
        }

        private string GetCss(CarouselItem item)
        {
            if (item.DisplayOrder == Center)
                return $"z-index: {Items.Count}";

            var offset = Center - item.DisplayOrder;
            int zindex = Items.Count - Math.Abs(offset);

            int translateX = offset * 300;
            int translateZ = Math.Abs(offset) * -90;
            int rotateY = (offset * -10) - 5;

            var text = $"z-index: {zindex}; transform: translateX({translateX}px) translateZ({translateZ}px) rotateY({rotateY}deg);";

            if (offset > 3)
                text += "content-visibility: hidden;";

            return text;
        }

        private void SelectItem(CarouselItem item)
        {
            if (Center == item.DisplayOrder)
            {
                Navigation.NavigateTo("play-game");
                return;
            }

            // Shift everything over
            var offset = Center - item.DisplayOrder;
            Items.ForEach(x => x.DisplayOrder += offset);

            // If something falls off the edge, move it to the opposite end
            Items.ForEach(x =>
            {
                if (x.DisplayOrder < 0)
                    x.DisplayOrder += Items.Count;
                else if (x.DisplayOrder > Items.Count)
                    x.DisplayOrder -= Items.Count;
            });

            StateHasChanged();
        }
    }
}
