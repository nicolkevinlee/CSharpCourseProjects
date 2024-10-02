using StarWarsPlanetsStatsApp.Enums;
using StarWarsPlanetsStatsApp.Objects;
using StarWarsPlanetsStatsApp.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPlanetsStatsApp.UI;

public interface IUserInterface
{
    PlanetProperties PromptUserForProperty();

    void ShowStatisticsForProperty(List<Planet> planets, PlanetProperties property);
}
