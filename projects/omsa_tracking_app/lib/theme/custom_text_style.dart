import 'package:flutter/material.dart';
import 'package:omsa_tracking_app/core/utils/size_utils.dart';
import 'package:omsa_tracking_app/theme/theme_helper.dart';

/// A collection of pre-defined text styles for customizing text appearance,
/// categorized by different font families and weights.
/// Additionally, this class includes extensions on [TextStyle] to easily apply specific font families to text.

class CustomTextStyles {
  // Body text style
  static get bodyLarge17 => theme.textTheme.bodyLarge!.copyWith(
        fontSize: 17.fSize,
      );
  static get bodyLargeLight => theme.textTheme.bodyLarge!.copyWith(
        fontSize: 17.fSize,
        fontWeight: FontWeight.w300,
      );
  static get bodySmall10 => theme.textTheme.bodySmall!.copyWith(
        fontSize: 10.fSize,
      );
  static get bodySmallLight => theme.textTheme.bodySmall!.copyWith(
        fontWeight: FontWeight.w300,
      );
  // Headline text style
  static get headlineSmallBold => theme.textTheme.headlineSmall!.copyWith(
        fontWeight: FontWeight.w700,
      );
  static get headlineSmallGray900 => theme.textTheme.headlineSmall!.copyWith(
        color: appTheme.gray900,
      );
  // Label text style
  static get labelLargeRed400 => theme.textTheme.labelLarge!.copyWith(
        color: appTheme.red400,
      );
}

extension on TextStyle {
  TextStyle get inter {
    return copyWith(
      fontFamily: 'Inter',
    );
  }

  TextStyle get roboto {
    return copyWith(
      fontFamily: 'Roboto',
    );
  }
}
