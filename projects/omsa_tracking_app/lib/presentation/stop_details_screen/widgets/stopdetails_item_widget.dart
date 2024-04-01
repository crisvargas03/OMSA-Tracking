import 'package:flutter/material.dart';
import 'package:omsa_tracking_app/core/app_export.dart';

// ignore: must_be_immutable
class StopdetailsItemWidget extends StatelessWidget {
  const StopdetailsItemWidget({Key? key})
      : super(
          key: key,
        );

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.symmetric(
        horizontal: 9.h,
        vertical: 13.v,
      ),
      decoration: AppDecoration.outlineBlack900.copyWith(
        borderRadius: BorderRadiusStyle.roundedBorder8,
      ),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.end,
        children: [
          CustomImageView(
            imagePath: ImageConstant.imgCar,
            width: 14.h,
            margin: EdgeInsets.only(left: 7.h),
          ),
          Padding(
            padding: EdgeInsets.only(
              left: 25.h,
              top: 2.v,
            ),
            child: Text(
              "Bus B340M",
              style: CustomTextStyles.bodySmallLight,
            ),
          ),
          Spacer(),
          CustomImageView(
            imagePath: ImageConstant.imgUpload,
            height: 14.v,
            margin: EdgeInsets.only(bottom: 2.v),
          ),
          Padding(
            padding: EdgeInsets.only(
              left: 6.h,
              top: 2.v,
            ),
            child: Text(
              "84 / 220",
              style: theme.textTheme.bodySmall,
            ),
          ),
          Padding(
            padding: EdgeInsets.only(
              left: 15.h,
              top: 2.v,
            ),
            child: Text(
              "Vencida",
              style: CustomTextStyles.labelLargeRed400,
            ),
          ),
        ],
      ),
    );
  }
}
