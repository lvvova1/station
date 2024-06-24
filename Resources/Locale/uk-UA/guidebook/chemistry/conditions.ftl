﻿reagent-effect-condition-guidebook-total-damage =
    { $max ->
        [2147483648] it has at least {NATURALFIXED($min, 2)} total damage
        *[other] { $min ->
                    [0] it has at most {NATURALFIXED($max, 2)} total damage
                    *[other] it has between {NATURALFIXED($min, 2)} and {NATURALFIXED($max, 2)} total damage
                 }
    }

reagent-effect-condition-guidebook-reagent-threshold = { $max ->
        [2147483648] є щонайменше {NATURALFIXED($min, 2)}u {$reagent}.
        *[other] { $min ->
                    [0] існує щонайбільше {NATURALFIXED($max, 2)}u {$reagent}
                    *[other] між {NATURALFIXED($min, 2)}u та {NATURALFIXED($max, 2)}u {$reagent}
                 }
    }

reagent-effect-condition-guidebook-mob-state-condition = моб - це { $state }

reagent-effect-condition-guidebook-solution-temperature = температура розчину дорівнює { $max ->
            [2147483648] не менше {NATURALFIXED($min, 2)}k
            *[other] { $min ->
                        [0] не більше {NATURALFIXED($max, 2)}k
                        *[other] між {NATURALFIXED($min, 2)}k та {NATURALFIXED($max, 2)}k
                     }
    }

reagent-effect-condition-guidebook-body-temperature = температура тіла становить { $max ->
            [2147483648] не менше {NATURALFIXED($min, 2)}k
            *[other] { $min ->
                        [0] не більше {NATURALFIXED($max, 2)}k
                        *[other] між {NATURALFIXED($min, 2)}k та {NATURALFIXED($max, 2)}k
                     }
    }

reagent-effect-condition-guidebook-organ-type = орган метаболізму { $shouldhave ->
                                [true] is
                                *[false] is not
                           } {INDEFINITE($name)} {$name} орган

reagent-effect-condition-guidebook-has-tag = ціль { $invert ->
                 [true] не має
                 *[false] має
                } тег {$tag}
