USE [master]
GO
/****** Object:  Database [Sanguosha-data]    Script Date: 2022/7/19 19:49:28 ******/
CREATE DATABASE [Sanguosha-data]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Sanguosha-data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Sanguosha-data.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Sanguosha-data_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Sanguosha-data_log.ldf' , SIZE = 139264KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Sanguosha-data] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Sanguosha-data].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Sanguosha-data] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Sanguosha-data] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Sanguosha-data] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Sanguosha-data] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Sanguosha-data] SET ARITHABORT OFF 
GO
ALTER DATABASE [Sanguosha-data] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Sanguosha-data] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Sanguosha-data] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Sanguosha-data] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Sanguosha-data] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Sanguosha-data] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Sanguosha-data] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Sanguosha-data] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Sanguosha-data] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Sanguosha-data] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Sanguosha-data] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Sanguosha-data] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Sanguosha-data] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Sanguosha-data] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Sanguosha-data] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Sanguosha-data] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Sanguosha-data] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Sanguosha-data] SET RECOVERY FULL 
GO
ALTER DATABASE [Sanguosha-data] SET  MULTI_USER 
GO
ALTER DATABASE [Sanguosha-data] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Sanguosha-data] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Sanguosha-data] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Sanguosha-data] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Sanguosha-data] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Sanguosha-data', N'ON'
GO
ALTER DATABASE [Sanguosha-data] SET QUERY_STORE = OFF
GO
USE [Sanguosha-data]
GO
/****** Object:  Table [dbo].[achieve]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[achieve](
	[achieve_id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[descript] [varchar](50) NOT NULL,
	[reward_title_id] [int] NULL,
	[reward_image1_id] [int] NULL,
	[reward_image2_id] [int] NULL,
	[reward_image3_id] [int] NULL,
 CONSTRAINT [PK_achieve] PRIMARY KEY CLUSTERED 
(
	[achieve_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ai_basic_card_value]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ai_basic_card_value](
	[card_name] [varchar](50) NOT NULL,
	[use_value] [float] NOT NULL,
	[keep_value] [float] NOT NULL,
	[priority] [float] NOT NULL,
 CONSTRAINT [PK_ai_basic_card_value] PRIMARY KEY CLUSTERED 
(
	[card_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ai_general_value]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ai_general_value](
	[general] [varchar](50) NOT NULL,
	[value] [float] NOT NULL,
	[mode] [varchar](50) NOT NULL,
	[ai_select] [bit] NOT NULL,
 CONSTRAINT [PK_ai_general_value] PRIMARY KEY CLUSTERED 
(
	[general] ASC,
	[mode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ai_pair_value]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ai_pair_value](
	[general1] [varchar](50) NOT NULL,
	[general2] [varchar](50) NOT NULL,
	[value1] [int] NOT NULL,
	[value2] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ai_skill_classify]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ai_skill_classify](
	[type] [varchar](50) NOT NULL,
	[skills] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ai_skill_coop_value]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ai_skill_coop_value](
	[skills] [varchar](50) NOT NULL,
	[value] [float] NOT NULL,
	[mode] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ai_skill_coop_value] PRIMARY KEY CLUSTERED 
(
	[skills] ASC,
	[mode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ai_skill_pair_value]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ai_skill_pair_value](
	[skills] [varchar](50) NOT NULL,
	[value] [float] NOT NULL,
 CONSTRAINT [PK_ai_skill_pair_value] PRIMARY KEY CLUSTERED 
(
	[skills] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ai_skill_value]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ai_skill_value](
	[skill_name] [varchar](50) NOT NULL,
	[value] [float] NOT NULL,
 CONSTRAINT [PK_ai_skill_value] PRIMARY KEY CLUSTERED 
(
	[skill_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bot_lines]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bot_lines](
	[id] [varchar](50) NOT NULL,
	[avatar] [int] NOT NULL,
	[frame] [int] NOT NULL,
	[bg] [int] NOT NULL,
	[title] [int] NOT NULL,
	[greeting] [nvarchar](max) NOT NULL,
	[death1] [nvarchar](max) NULL,
	[death2] [nvarchar](max) NULL,
	[slash_target1] [nvarchar](max) NULL,
	[slash_target2] [nvarchar](max) NULL,
	[slash_use1] [nvarchar](max) NULL,
	[slash_use2] [nvarchar](max) NULL,
	[damaged1] [nvarchar](max) NULL,
	[damaged2] [nvarchar](max) NULL,
	[kill1] [nvarchar](max) NULL,
	[kill2] [nvarchar](max) NULL,
	[other_drunk1] [nvarchar](max) NULL,
	[other_drunk2] [nvarchar](max) NULL,
	[indu_success1] [nvarchar](max) NULL,
	[indu_success2] [nvarchar](max) NULL,
	[indu_fail1] [nvarchar](max) NULL,
	[indu_fail2] [nvarchar](max) NULL,
	[lightning_success1] [nvarchar](max) NULL,
	[lightning_success2] [nvarchar](max) NULL,
	[duel_win1] [nvarchar](max) NULL,
	[duel_win2] [nvarchar](max) NULL,
	[idle_talk] [nvarchar](max) NULL,
 CONSTRAINT [PK_ai_lines] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bot_skill_lines]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bot_skill_lines](
	[trigger] [varchar](max) NOT NULL,
	[skills] [varchar](max) NOT NULL,
	[self_lines1] [varchar](max) NULL,
	[self_lines2] [varchar](max) NULL,
	[self_emotion1] [varchar](max) NULL,
	[self_emotion2] [varchar](max) NULL,
	[lines1] [varchar](max) NULL,
	[lines2] [varchar](max) NULL,
	[emotion1] [varchar](max) NULL,
	[emotion2] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[card_package]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[card_package](
	[package_name] [varchar](50) NOT NULL,
	[mode] [varchar](50) NOT NULL,
	[translation] [varchar](50) NOT NULL,
	[index] [int] NOT NULL,
	[enable] [bit] NOT NULL,
 CONSTRAINT [PK_card_package] PRIMARY KEY CLUSTERED 
(
	[package_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cards]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cards](
	[id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[suit] [varchar](50) NOT NULL,
	[number] [int] NOT NULL,
	[type] [varchar](50) NOT NULL,
	[mode] [varchar](50) NOT NULL,
	[package] [varchar](50) NOT NULL,
	[transferable] [bit] NOT NULL,
	[can_recast] [bit] NOT NULL,
 CONSTRAINT [PK_cards] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[function_card]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[function_card](
	[index] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[name_translation] [varchar](50) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[description] [varchar](max) NOT NULL,
 CONSTRAINT [PK_function_card_1] PRIMARY KEY CLUSTERED 
(
	[index] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[game_mode]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[game_mode](
	[mode_name] [varchar](50) NOT NULL,
	[players_count] [int] NOT NULL,
	[is_scenario] [bit] NOT NULL,
	[index] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[general_hp_adjust]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[general_hp_adjust](
	[general_name] [varchar](50) NOT NULL,
	[hp_adjust] [int] NOT NULL,
	[is_head] [bit] NOT NULL,
 CONSTRAINT [PK_general_hp_adjust] PRIMARY KEY CLUSTERED 
(
	[general_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[general_lines]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[general_lines](
	[skill_name] [varchar](50) NOT NULL,
	[general_name] [varchar](50) NOT NULL,
	[skin_id] [int] NOT NULL,
	[lines] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[general_package]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[general_package](
	[package_name] [varchar](50) NOT NULL,
	[mode] [varchar](50) NOT NULL,
	[translation] [varchar](max) NOT NULL,
	[index] [int] NOT NULL,
	[enable] [bit] NOT NULL,
 CONSTRAINT [PK_general_package] PRIMARY KEY CLUSTERED 
(
	[package_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[general_skill]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[general_skill](
	[general] [varchar](50) NOT NULL,
	[skill_names] [varchar](max) NOT NULL,
	[related_skills] [varchar](max) NULL,
	[mode] [varchar](50) NOT NULL,
 CONSTRAINT [PK_general_skill] PRIMARY KEY CLUSTERED 
(
	[general] ASC,
	[mode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[general_skin]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[general_skin](
	[general_name] [varchar](50) NOT NULL,
	[skin_id] [int] NOT NULL,
	[title] [varchar](50) NOT NULL,
	[dynamic_ol] [bit] NOT NULL,
	[dynamic_mobile] [bit] NOT NULL,
	[quality] [int] NULL,
	[CV] [varchar](50) NULL,
	[illustrator] [varchar](50) NULL,
	[mode] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[generals]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[generals](
	[general_name] [varchar](50) NOT NULL,
	[sex] [bit] NOT NULL,
	[kingdom] [varchar](50) NOT NULL,
	[HP] [int] NOT NULL,
	[adjust_hp] [int] NOT NULL,
	[package] [varchar](50) NOT NULL,
	[lord] [bit] NOT NULL,
	[selectable] [bit] NOT NULL,
	[hidden] [bit] NOT NULL,
	[main] [varchar](50) NULL,
	[companion] [varchar](50) NULL,
	[translation] [varchar](50) NULL,
 CONSTRAINT [PK_generals] PRIMARY KEY CLUSTERED 
(
	[general_name] ASC,
	[package] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[huashen_ban_list]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[huashen_ban_list](
	[general] [varchar](50) NOT NULL,
 CONSTRAINT [PK_huashen_ban_list] PRIMARY KEY CLUSTERED 
(
	[general] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role_tendency]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role_tendency](
	[general] [varchar](50) NOT NULL,
	[lord] [int] NOT NULL,
	[loyalist] [int] NOT NULL,
	[rebel] [int] NOT NULL,
	[renegade] [int] NOT NULL,
 CONSTRAINT [PK_role_tendency] PRIMARY KEY CLUSTERED 
(
	[general] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[show_avatar]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[show_avatar](
	[id] [int] NOT NULL,
	[title] [varchar](50) NOT NULL,
	[dynamic] [bit] NOT NULL,
	[skel_animation] [bit] NOT NULL,
	[private_avatar] [bit] NOT NULL,
	[full_avatar] [bit] NOT NULL,
 CONSTRAINT [PK_show_avatar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[show_bg]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[show_bg](
	[id] [int] NOT NULL,
	[title] [varchar](50) NOT NULL,
	[dynamic] [bit] NOT NULL,
	[skel_animation] [bit] NOT NULL,
 CONSTRAINT [PK_show_bg] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[show_frame]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[show_frame](
	[id] [int] NOT NULL,
	[title] [varchar](50) NOT NULL,
	[dynamic] [bit] NOT NULL,
	[skel_animation] [bit] NOT NULL,
 CONSTRAINT [PK_show_border] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[skills]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[skills](
	[index] [int] NOT NULL,
	[skill_name] [varchar](50) NOT NULL,
	[preshow] [bit] NOT NULL,
	[frequency] [int] NOT NULL,
	[passive] [bit] NOT NULL,
	[attach_lord] [bit] NOT NULL,
	[translation] [varchar](50) NOT NULL,
	[description] [varchar](max) NOT NULL,
	[frequency1] [int] NOT NULL,
	[frequency2] [int] NOT NULL,
	[frequency3] [int] NOT NULL,
	[description1] [varchar](max) NULL,
	[description2] [varchar](max) NULL,
	[description3] [varchar](max) NULL,
 CONSTRAINT [PK_skills] PRIMARY KEY CLUSTERED 
(
	[index] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[title]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[title](
	[title_id] [int] NOT NULL,
	[title_name] [varchar](50) NOT NULL,
	[describe] [varchar](max) NULL,
	[translation] [varchar](50) NULL,
	[requirement] [varchar](max) NULL,
	[designer] [varchar](50) NULL,
 CONSTRAINT [PK_title] PRIMARY KEY CLUSTERED 
(
	[title_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[title_marks]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[title_marks](
	[mark_id] [int] NOT NULL,
	[target_id] [int] NOT NULL,
	[description] [varchar](max) NULL,
 CONSTRAINT [PK_title_marks] PRIMARY KEY CLUSTERED 
(
	[mark_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[translation]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[translation](
	[key] [varchar](50) NOT NULL,
	[translation] [nvarchar](max) NOT NULL,
	[path] [varchar](50) NULL,
 CONSTRAINT [PK_translation] PRIMARY KEY CLUSTERED 
(
	[key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zhaoxiang_skills]    Script Date: 2022/7/19 19:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zhaoxiang_skills](
	[general_name] [varchar](50) NOT NULL,
	[general_translation] [varchar](max) NOT NULL,
	[skills] [varchar](50) NOT NULL,
	[package] [varchar](50) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_show_bg]    Script Date: 2022/7/19 19:49:29 ******/
CREATE NONCLUSTERED COLUMNSTORE INDEX [IX_show_bg] ON [dbo].[show_bg]
(
	[title]
)WITH (DROP_EXISTING = OFF, COMPRESSION_DELAY = 0) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ai_general_value] ADD  CONSTRAINT [DF_ai_general_value_ai_select]  DEFAULT ((1)) FOR [ai_select]
GO
ALTER TABLE [dbo].[card_package] ADD  CONSTRAINT [DF_card_package_enable]  DEFAULT ((1)) FOR [enable]
GO
ALTER TABLE [dbo].[cards] ADD  CONSTRAINT [DF_cards_transferable]  DEFAULT ((0)) FOR [transferable]
GO
ALTER TABLE [dbo].[cards] ADD  CONSTRAINT [DF_cards_can_recast]  DEFAULT ((0)) FOR [can_recast]
GO
ALTER TABLE [dbo].[general_package] ADD  CONSTRAINT [DF_general_package_enable]  DEFAULT ((1)) FOR [enable]
GO
ALTER TABLE [dbo].[general_skin] ADD  CONSTRAINT [DF_general_skin_dynamic_ol]  DEFAULT ((0)) FOR [dynamic_ol]
GO
ALTER TABLE [dbo].[general_skin] ADD  CONSTRAINT [DF_general_skin_dynamic_mobile]  DEFAULT ((0)) FOR [dynamic_mobile]
GO
ALTER TABLE [dbo].[general_skin] ADD  CONSTRAINT [DF_general_skin_quality]  DEFAULT ((0)) FOR [quality]
GO
ALTER TABLE [dbo].[generals] ADD  CONSTRAINT [DF_generals_adjust_hp]  DEFAULT ((0)) FOR [adjust_hp]
GO
ALTER TABLE [dbo].[generals] ADD  CONSTRAINT [DF_generals_selectable]  DEFAULT ((1)) FOR [selectable]
GO
ALTER TABLE [dbo].[generals] ADD  CONSTRAINT [DF_generals_hidden]  DEFAULT ((0)) FOR [hidden]
GO
ALTER TABLE [dbo].[role_tendency] ADD  CONSTRAINT [DF_role_tendency_lord]  DEFAULT ((0)) FOR [lord]
GO
ALTER TABLE [dbo].[role_tendency] ADD  CONSTRAINT [DF_role_tendency_royalist]  DEFAULT ((0)) FOR [loyalist]
GO
ALTER TABLE [dbo].[role_tendency] ADD  CONSTRAINT [DF_role_tendency_rebel]  DEFAULT ((0)) FOR [rebel]
GO
ALTER TABLE [dbo].[role_tendency] ADD  CONSTRAINT [DF_role_tendency_renegade]  DEFAULT ((0)) FOR [renegade]
GO
ALTER TABLE [dbo].[show_avatar] ADD  CONSTRAINT [DF_show_avatar_dynamic]  DEFAULT ((0)) FOR [dynamic]
GO
ALTER TABLE [dbo].[show_avatar] ADD  CONSTRAINT [DF_show_avatar_skel_animation]  DEFAULT ((0)) FOR [skel_animation]
GO
ALTER TABLE [dbo].[show_avatar] ADD  CONSTRAINT [DF_show_avatar_full]  DEFAULT ((0)) FOR [private_avatar]
GO
ALTER TABLE [dbo].[show_avatar] ADD  CONSTRAINT [DF_show_avatar_full_avatar]  DEFAULT ((0)) FOR [full_avatar]
GO
ALTER TABLE [dbo].[show_bg] ADD  CONSTRAINT [DF_show_bg_dynamic]  DEFAULT ((0)) FOR [dynamic]
GO
ALTER TABLE [dbo].[show_bg] ADD  CONSTRAINT [DF_show_bg_skel_animation]  DEFAULT ((0)) FOR [skel_animation]
GO
ALTER TABLE [dbo].[show_frame] ADD  CONSTRAINT [DF_show_border_dynamic]  DEFAULT ((0)) FOR [dynamic]
GO
ALTER TABLE [dbo].[show_frame] ADD  CONSTRAINT [DF_show_frame_skel_animation]  DEFAULT ((0)) FOR [skel_animation]
GO
ALTER TABLE [dbo].[skills] ADD  CONSTRAINT [DF_skills_]  DEFAULT ((1)) FOR [passive]
GO
ALTER TABLE [dbo].[skills] ADD  CONSTRAINT [DF_skills_attach_lord]  DEFAULT ((0)) FOR [attach_lord]
GO
ALTER TABLE [dbo].[skills] ADD  CONSTRAINT [DF_skills_frequency1]  DEFAULT ((0)) FOR [frequency1]
GO
ALTER TABLE [dbo].[skills] ADD  CONSTRAINT [DF_skills_frequency2]  DEFAULT ((0)) FOR [frequency2]
GO
ALTER TABLE [dbo].[skills] ADD  CONSTRAINT [DF_skills_frequency3]  DEFAULT ((0)) FOR [frequency3]
GO
ALTER TABLE [dbo].[achieve]  WITH CHECK ADD  CONSTRAINT [FK_achieve_title] FOREIGN KEY([reward_title_id])
REFERENCES [dbo].[title] ([title_id])
GO
ALTER TABLE [dbo].[achieve] CHECK CONSTRAINT [FK_achieve_title]
GO
ALTER TABLE [dbo].[cards]  WITH CHECK ADD  CONSTRAINT [FK_cards_card_package] FOREIGN KEY([package])
REFERENCES [dbo].[card_package] ([package_name])
GO
ALTER TABLE [dbo].[cards] CHECK CONSTRAINT [FK_cards_card_package]
GO
ALTER TABLE [dbo].[cards]  WITH CHECK ADD  CONSTRAINT [卡牌花色] CHECK  (([suit]='club' OR [suit]='diamond' OR [suit]='heart' OR [suit]='spade'))
GO
ALTER TABLE [dbo].[cards] CHECK CONSTRAINT [卡牌花色]
GO
ALTER TABLE [dbo].[cards]  WITH CHECK ADD  CONSTRAINT [卡牌类型] CHECK  (([type]='basic' OR [type]='equip' OR [type]='trick'))
GO
ALTER TABLE [dbo].[cards] CHECK CONSTRAINT [卡牌类型]
GO
ALTER TABLE [dbo].[cards]  WITH CHECK ADD  CONSTRAINT [卡牌数字在A~K之间] CHECK  (([number]>=(1) AND [number]<=(13)))
GO
ALTER TABLE [dbo].[cards] CHECK CONSTRAINT [卡牌数字在A~K之间]
GO
ALTER TABLE [dbo].[general_skin]  WITH CHECK ADD  CONSTRAINT [id] CHECK  (([skin_id]>=(0)))
GO
ALTER TABLE [dbo].[general_skin] CHECK CONSTRAINT [id]
GO
ALTER TABLE [dbo].[generals]  WITH CHECK ADD  CONSTRAINT [kingdom] CHECK  (([kingdom] like '%wu%' OR [kingdom] like '%shu%' OR [kingdom] like '%wei%' OR [kingdom] like '%qun%' OR [kingdom]='god'))
GO
ALTER TABLE [dbo].[generals] CHECK CONSTRAINT [kingdom]
GO
USE [master]
GO
ALTER DATABASE [Sanguosha-data] SET  READ_WRITE 
GO
