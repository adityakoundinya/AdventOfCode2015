using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaCircuit
{

    class Program
    {
        static Dictionary<string, ushort> wireSignals = new Dictionary<string, ushort>();
        static List<string> unprocessed = new List<string>();

        static void Main(string [] args)
        {
            string input = "NOT_dq_->_dr,kg_OR_kf_->_kh,ep_OR_eo_->_eq,3176_->_b,NOT_gs_->_gt,dd_OR_do_->_dp,eg_AND_ei_->_ej,y_AND_ae_->_ag,jx_AND_jz_->_ka,lf_RSHIFT_2_->_lg,z_AND_aa_->_ac,dy_AND_ej_->_el,bj_OR_bi_->_bk,kk_RSHIFT_3_->_km,NOT_cn_->_co,gn_AND_gp_->_gq,cq_AND_cs_->_ct,eo_LSHIFT_15_->_es,lg_OR_lm_->_ln,dy_OR_ej_->_ek,NOT_di_->_dj,1_AND_fi_->_fj,kf_LSHIFT_15_->_kj,NOT_jy_->_jz,NOT_ft_->_fu,fs_AND_fu_->_fv,NOT_hr_->_hs,ck_OR_cl_->_cm,jp_RSHIFT_5_->_js,iv_OR_jb_->_jc,is_OR_it_->_iu,ld_OR_le_->_lf,NOT_fc_->_fd,NOT_dm_->_dn,bn_OR_by_->_bz,aj_AND_al_->_am,cd_LSHIFT_15_->_ch,jp_AND_ka_->_kc,ci_OR_ct_->_cu,gv_AND_gx_->_gy,de_AND_dk_->_dm,x_RSHIFT_5_->_aa,et_RSHIFT_2_->_eu,x_RSHIFT_1_->_aq,ia_OR_ig_->_ih,bk_LSHIFT_1_->_ce,y_OR_ae_->_af,NOT_ca_->_cb,e_AND_f_->_h,ia_AND_ig_->_ii,ck_AND_cl_->_cn,NOT_jh_->_ji,z_OR_aa_->_ab,1_AND_en_->_eo,ib_AND_ic_->_ie,NOT_eh_->_ei,iy_AND_ja_->_jb,NOT_bb_->_bc,ha_OR_gz_->_hb,1_AND_cx_->_cy,NOT_ax_->_ay,ev_OR_ew_->_ex,bn_RSHIFT_2_->_bo,er_OR_es_->_et,eu_OR_fa_->_fb,jp_OR_ka_->_kb,ea_AND_eb_->_ed,k_AND_m_->_n,et_RSHIFT_3_->_ev,et_RSHIFT_5_->_ew,hz_RSHIFT_1_->_is,ki_OR_kj_->_kk,NOT_h_->_i,lv_LSHIFT_15_->_lz,as_RSHIFT_1_->_bl,hu_LSHIFT_15_->_hy,iw_AND_ix_->_iz,lf_RSHIFT_1_->_ly,fp_OR_fv_->_fw,1_AND_am_->_an,ap_LSHIFT_1_->_bj,u_LSHIFT_1_->_ao,b_RSHIFT_5_->_f,jq_AND_jw_->_jy,iu_RSHIFT_3_->_iw,ih_AND_ij_->_ik,NOT_iz_->_ja,de_OR_dk_->_dl,iu_OR_jf_->_jg,as_AND_bd_->_bf,b_RSHIFT_3_->_e,jq_OR_jw_->_jx,iv_AND_jb_->_jd,cg_OR_ch_->_ci,iu_AND_jf_->_jh,lx_->_a,1_AND_cc_->_cd,ly_OR_lz_->_ma,NOT_el_->_em,1_AND_bh_->_bi,fb_AND_fd_->_fe,lf_OR_lq_->_lr,bn_RSHIFT_3_->_bp,bn_AND_by_->_ca,af_AND_ah_->_ai,cf_LSHIFT_1_->_cz,dw_OR_dx_->_dy,gj_AND_gu_->_gw,jg_AND_ji_->_jj,jr_OR_js_->_jt,bl_OR_bm_->_bn,gj_RSHIFT_2_->_gk,cj_OR_cp_->_cq,gj_OR_gu_->_gv,b_OR_n_->_o,o_AND_q_->_r,bi_LSHIFT_15_->_bm,dy_RSHIFT_1_->_er,cu_AND_cw_->_cx,iw_OR_ix_->_iy,hc_OR_hd_->_he,0_->_c,db_OR_dc_->_dd,kk_RSHIFT_2_->_kl,eq_LSHIFT_1_->_fk,dz_OR_ef_->_eg,NOT_ed_->_ee,lw_OR_lv_->_lx,fw_AND_fy_->_fz,dz_AND_ef_->_eh,jp_RSHIFT_3_->_jr,lg_AND_lm_->_lo,ci_RSHIFT_2_->_cj,be_AND_bg_->_bh,lc_LSHIFT_1_->_lw,hm_AND_ho_->_hp,jr_AND_js_->_ju,1_AND_io_->_ip,cm_AND_co_->_cp,ib_OR_ic_->_id,NOT_bf_->_bg,fo_RSHIFT_5_->_fr,ip_LSHIFT_15_->_it,jt_AND_jv_->_jw,jc_AND_je_->_jf,du_OR_dt_->_dv,NOT_fx_->_fy,aw_AND_ay_->_az,ge_LSHIFT_15_->_gi,NOT_ak_->_al,fm_OR_fn_->_fo,ff_AND_fh_->_fi,ci_RSHIFT_5_->_cl,cz_OR_cy_->_da,NOT_ey_->_ez,NOT_ju_->_jv,NOT_ls_->_lt,kk_AND_kv_->_kx,NOT_ii_->_ij,kl_AND_kr_->_kt,jk_LSHIFT_15_->_jo,e_OR_f_->_g,NOT_bs_->_bt,hi_AND_hk_->_hl,hz_OR_ik_->_il,ek_AND_em_->_en,ao_OR_an_->_ap,dv_LSHIFT_1_->_ep,an_LSHIFT_15_->_ar,fo_RSHIFT_1_->_gh,NOT_im_->_in,kk_RSHIFT_1_->_ld,hw_LSHIFT_1_->_iq,ec_AND_ee_->_ef,hb_LSHIFT_1_->_hv,kb_AND_kd_->_ke,x_AND_ai_->_ak,dd_AND_do_->_dq,aq_OR_ar_->_as,iq_OR_ip_->_ir,dl_AND_dn_->_do,iu_RSHIFT_5_->_ix,as_OR_bd_->_be,NOT_go_->_gp,fk_OR_fj_->_fl,jm_LSHIFT_1_->_kg,NOT_cv_->_cw,dp_AND_dr_->_ds,dt_LSHIFT_15_->_dx,et_RSHIFT_1_->_fm,dy_RSHIFT_3_->_ea,fp_AND_fv_->_fx,NOT_p_->_q,dd_RSHIFT_2_->_de,eu_AND_fa_->_fc,ba_AND_bc_->_bd,dh_AND_dj_->_dk,lr_AND_lt_->_lu,he_RSHIFT_1_->_hx,ex_AND_ez_->_fa,df_OR_dg_->_dh,fj_LSHIFT_15_->_fn,NOT_kx_->_ky,gk_OR_gq_->_gr,dy_RSHIFT_2_->_dz,gh_OR_gi_->_gj,lj_AND_ll_->_lm,x_OR_ai_->_aj,bz_AND_cb_->_cc,1_AND_lu_->_lv,as_RSHIFT_3_->_au,ce_OR_cd_->_cf,il_AND_in_->_io,dd_RSHIFT_1_->_dw,NOT_lo_->_lp,c_LSHIFT_1_->_t,dd_RSHIFT_3_->_df,dd_RSHIFT_5_->_dg,lh_AND_li_->_lk,lf_RSHIFT_5_->_li,dy_RSHIFT_5_->_eb,NOT_kt_->_ku,at_OR_az_->_ba,x_RSHIFT_3_->_z,NOT_lk_->_ll,lb_OR_la_->_lc,1_AND_r_->_s,lh_OR_li_->_lj,ln_AND_lp_->_lq,kk_RSHIFT_5_->_kn,ea_OR_eb_->_ec,ci_AND_ct_->_cv,b_RSHIFT_2_->_d,jp_RSHIFT_1_->_ki,NOT_cr_->_cs,NOT_jd_->_je,jp_RSHIFT_2_->_jq,jn_OR_jo_->_jp,lf_RSHIFT_3_->_lh,1_AND_ds_->_dt,lf_AND_lq_->_ls,la_LSHIFT_15_->_le,NOT_fg_->_fh,at_AND_az_->_bb,au_AND_av_->_ax,kw_AND_ky_->_kz,v_OR_w_->_x,kk_OR_kv_->_kw,ks_AND_ku_->_kv,kh_LSHIFT_1_->_lb,1_AND_kz_->_la,NOT_kc_->_kd,x_RSHIFT_2_->_y,et_OR_fe_->_ff,et_AND_fe_->_fg,NOT_ac_->_ad,jl_OR_jk_->_jm,1_AND_jj_->_jk,bn_RSHIFT_1_->_cg,NOT_kp_->_kq,ci_RSHIFT_3_->_ck,ev_AND_ew_->_ey,1_AND_ke_->_kf,cj_AND_cp_->_cr,ir_LSHIFT_1_->_jl,NOT_gw_->_gx,as_RSHIFT_2_->_at,iu_RSHIFT_1_->_jn,cy_LSHIFT_15_->_dc,hg_OR_hh_->_hi,ci_RSHIFT_1_->_db,au_OR_av_->_aw,km_AND_kn_->_kp,gj_RSHIFT_1_->_hc,iu_RSHIFT_2_->_iv,ab_AND_ad_->_ae,da_LSHIFT_1_->_du,NOT_bw_->_bx,km_OR_kn_->_ko,ko_AND_kq_->_kr,bv_AND_bx_->_by,kl_OR_kr_->_ks,1_AND_ht_->_hu,df_AND_dg_->_di,NOT_ag_->_ah,d_OR_j_->_k,d_AND_j_->_l,b_AND_n_->_p,gf_OR_ge_->_gg,gg_LSHIFT_1_->_ha,bn_RSHIFT_5_->_bq,bo_OR_bu_->_bv,1_AND_gy_->_gz,s_LSHIFT_15_->_w,NOT_ie_->_if,as_RSHIFT_5_->_av,bo_AND_bu_->_bw,hz_AND_ik_->_im,bp_AND_bq_->_bs,b_RSHIFT_1_->_v,NOT_l_->_m,bp_OR_bq_->_br,g_AND_i_->_j,br_AND_bt_->_bu,t_OR_s_->_u,hz_RSHIFT_5_->_ic,gk_AND_gq_->_gs,fl_LSHIFT_1_->_gf,he_RSHIFT_3_->_hg,gz_LSHIFT_15_->_hd,hf_OR_hl_->_hm,1_AND_gd_->_ge,fo_OR_fz_->_ga,id_AND_if_->_ig,fo_AND_fz_->_gb,gr_AND_gt_->_gu,he_OR_hp_->_hq,fq_AND_fr_->_ft,ga_AND_gc_->_gd,fo_RSHIFT_2_->_fp,gl_OR_gm_->_gn,hg_AND_hh_->_hj,NOT_hn_->_ho,gl_AND_gm_->_go,he_RSHIFT_5_->_hh,NOT_gb_->_gc,hq_AND_hs_->_ht,hz_RSHIFT_3_->_ib,hz_RSHIFT_2_->_ia,fq_OR_fr_->_fs,hx_OR_hy_->_hz,he_AND_hp_->_hr,gj_RSHIFT_5_->_gm,hf_AND_hl_->_hn,hv_OR_hu_->_hw,NOT_hj_->_hk,gj_RSHIFT_3_->_gl,fo_RSHIFT_3_->_fq,he_RSHIFT_2_->_hf";
            //string input = "lf_AND_lq_->_ls,iu_RSHIFT_1_->_jn,bo_OR_bu_->_bv,gj_RSHIFT_1_->_hc,et_RSHIFT_2_->_eu,bv_AND_bx_->_by,is_OR_it_->_iu,b_OR_n_->_o,gf_OR_ge_->_gg,NOT_kt_->_ku,ea_AND_eb_->_ed,kl_OR_kr_->_ks,hi_AND_hk_->_hl,au_AND_av_->_ax,lf_RSHIFT_2_->_lg,dd_RSHIFT_3_->_df,eu_AND_fa_->_fc,df_AND_dg_->_di,ip_LSHIFT_15_->_it,NOT_el_->_em,et_OR_fe_->_ff,fj_LSHIFT_15_->_fn,t_OR_s_->_u,ly_OR_lz_->_ma,ko_AND_kq_->_kr,NOT_fx_->_fy,et_RSHIFT_1_->_fm,eu_OR_fa_->_fb,dd_RSHIFT_2_->_de,NOT_go_->_gp,kb_AND_kd_->_ke,hg_OR_hh_->_hi,jm_LSHIFT_1_->_kg,NOT_cn_->_co,jp_RSHIFT_2_->_jq,jp_RSHIFT_5_->_js,1_AND_io_->_ip,eo_LSHIFT_15_->_es,1_AND_jj_->_jk,g_AND_i_->_j,ci_RSHIFT_3_->_ck,gn_AND_gp_->_gq,fs_AND_fu_->_fv,lj_AND_ll_->_lm,jk_LSHIFT_15_->_jo,iu_RSHIFT_3_->_iw,NOT_ii_->_ij,1_AND_cc_->_cd,bn_RSHIFT_3_->_bp,NOT_gw_->_gx,NOT_ft_->_fu,jn_OR_jo_->_jp,iv_OR_jb_->_jc,hv_OR_hu_->_hw,19138_->_b,gj_RSHIFT_5_->_gm,hq_AND_hs_->_ht,dy_RSHIFT_1_->_er,ao_OR_an_->_ap,ld_OR_le_->_lf,bk_LSHIFT_1_->_ce,bz_AND_cb_->_cc,bi_LSHIFT_15_->_bm,il_AND_in_->_io,af_AND_ah_->_ai,as_RSHIFT_1_->_bl,lf_RSHIFT_3_->_lh,er_OR_es_->_et,NOT_ax_->_ay,ci_RSHIFT_1_->_db,et_AND_fe_->_fg,lg_OR_lm_->_ln,k_AND_m_->_n,hz_RSHIFT_2_->_ia,kh_LSHIFT_1_->_lb,NOT_ey_->_ez,NOT_di_->_dj,dz_OR_ef_->_eg,lx_->_a,NOT_iz_->_ja,gz_LSHIFT_15_->_hd,ce_OR_cd_->_cf,fq_AND_fr_->_ft,at_AND_az_->_bb,ha_OR_gz_->_hb,fp_AND_fv_->_fx,NOT_gb_->_gc,ia_AND_ig_->_ii,gl_OR_gm_->_gn,0_->_c,NOT_ca_->_cb,bn_RSHIFT_1_->_cg,c_LSHIFT_1_->_t,iw_OR_ix_->_iy,kg_OR_kf_->_kh,dy_OR_ej_->_ek,km_AND_kn_->_kp,NOT_fc_->_fd,hz_RSHIFT_3_->_ib,NOT_dq_->_dr,NOT_fg_->_fh,dy_RSHIFT_2_->_dz,kk_RSHIFT_2_->_kl,1_AND_fi_->_fj,NOT_hr_->_hs,jp_RSHIFT_1_->_ki,bl_OR_bm_->_bn,1_AND_gy_->_gz,gr_AND_gt_->_gu,db_OR_dc_->_dd,de_OR_dk_->_dl,as_RSHIFT_5_->_av,lf_RSHIFT_5_->_li,hm_AND_ho_->_hp,cg_OR_ch_->_ci,gj_AND_gu_->_gw,ge_LSHIFT_15_->_gi,e_OR_f_->_g,fp_OR_fv_->_fw,fb_AND_fd_->_fe,cd_LSHIFT_15_->_ch,b_RSHIFT_1_->_v,at_OR_az_->_ba,bn_RSHIFT_2_->_bo,lh_AND_li_->_lk,dl_AND_dn_->_do,eg_AND_ei_->_ej,ex_AND_ez_->_fa,NOT_kp_->_kq,NOT_lk_->_ll,x_AND_ai_->_ak,jp_OR_ka_->_kb,NOT_jd_->_je,iy_AND_ja_->_jb,jp_RSHIFT_3_->_jr,fo_OR_fz_->_ga,df_OR_dg_->_dh,gj_RSHIFT_2_->_gk,gj_OR_gu_->_gv,NOT_jh_->_ji,ap_LSHIFT_1_->_bj,NOT_ls_->_lt,ir_LSHIFT_1_->_jl,bn_AND_by_->_ca,lv_LSHIFT_15_->_lz,ba_AND_bc_->_bd,cy_LSHIFT_15_->_dc,ln_AND_lp_->_lq,x_RSHIFT_1_->_aq,gk_OR_gq_->_gr,NOT_kx_->_ky,jg_AND_ji_->_jj,bn_OR_by_->_bz,fl_LSHIFT_1_->_gf,bp_OR_bq_->_br,he_OR_hp_->_hq,et_RSHIFT_5_->_ew,iu_RSHIFT_2_->_iv,gl_AND_gm_->_go,x_OR_ai_->_aj,hc_OR_hd_->_he,lg_AND_lm_->_lo,lh_OR_li_->_lj,da_LSHIFT_1_->_du,fo_RSHIFT_2_->_fp,gk_AND_gq_->_gs,bj_OR_bi_->_bk,lf_OR_lq_->_lr,cj_AND_cp_->_cr,hu_LSHIFT_15_->_hy,1_AND_bh_->_bi,fo_RSHIFT_3_->_fq,NOT_lo_->_lp,hw_LSHIFT_1_->_iq,dd_RSHIFT_1_->_dw,dt_LSHIFT_15_->_dx,dy_AND_ej_->_el,an_LSHIFT_15_->_ar,aq_OR_ar_->_as,1_AND_r_->_s,fw_AND_fy_->_fz,NOT_im_->_in,et_RSHIFT_3_->_ev,1_AND_ds_->_dt,ec_AND_ee_->_ef,NOT_ak_->_al,jl_OR_jk_->_jm,1_AND_en_->_eo,lb_OR_la_->_lc,iu_AND_jf_->_jh,iu_RSHIFT_5_->_ix,bo_AND_bu_->_bw,cz_OR_cy_->_da,iv_AND_jb_->_jd,iw_AND_ix_->_iz,lf_RSHIFT_1_->_ly,iu_OR_jf_->_jg,NOT_dm_->_dn,lw_OR_lv_->_lx,gg_LSHIFT_1_->_ha,lr_AND_lt_->_lu,fm_OR_fn_->_fo,he_RSHIFT_3_->_hg,aj_AND_al_->_am,1_AND_kz_->_la,dy_RSHIFT_5_->_eb,jc_AND_je_->_jf,cm_AND_co_->_cp,gv_AND_gx_->_gy,ev_OR_ew_->_ex,jp_AND_ka_->_kc,fk_OR_fj_->_fl,dy_RSHIFT_3_->_ea,NOT_bs_->_bt,NOT_ag_->_ah,dz_AND_ef_->_eh,cf_LSHIFT_1_->_cz,NOT_cv_->_cw,1_AND_cx_->_cy,de_AND_dk_->_dm,ck_AND_cl_->_cn,x_RSHIFT_5_->_aa,dv_LSHIFT_1_->_ep,he_RSHIFT_2_->_hf,NOT_bw_->_bx,ck_OR_cl_->_cm,bp_AND_bq_->_bs,as_OR_bd_->_be,he_AND_hp_->_hr,ev_AND_ew_->_ey,1_AND_lu_->_lv,kk_RSHIFT_3_->_km,b_AND_n_->_p,NOT_kc_->_kd,lc_LSHIFT_1_->_lw,km_OR_kn_->_ko,id_AND_if_->_ig,ih_AND_ij_->_ik,jr_AND_js_->_ju,ci_RSHIFT_5_->_cl,hz_RSHIFT_1_->_is,1_AND_ke_->_kf,NOT_gs_->_gt,aw_AND_ay_->_az,x_RSHIFT_2_->_y,ab_AND_ad_->_ae,ff_AND_fh_->_fi,ci_AND_ct_->_cv,eq_LSHIFT_1_->_fk,gj_RSHIFT_3_->_gl,u_LSHIFT_1_->_ao,NOT_bb_->_bc,NOT_hj_->_hk,kw_AND_ky_->_kz,as_AND_bd_->_bf,dw_OR_dx_->_dy,br_AND_bt_->_bu,kk_AND_kv_->_kx,ep_OR_eo_->_eq,he_RSHIFT_1_->_hx,ki_OR_kj_->_kk,NOT_ju_->_jv,ek_AND_em_->_en,kk_RSHIFT_5_->_kn,NOT_eh_->_ei,hx_OR_hy_->_hz,ea_OR_eb_->_ec,s_LSHIFT_15_->_w,fo_RSHIFT_1_->_gh,kk_OR_kv_->_kw,bn_RSHIFT_5_->_bq,NOT_ed_->_ee,1_AND_ht_->_hu,cu_AND_cw_->_cx,b_RSHIFT_5_->_f,kl_AND_kr_->_kt,iq_OR_ip_->_ir,ci_RSHIFT_2_->_cj,cj_OR_cp_->_cq,o_AND_q_->_r,dd_RSHIFT_5_->_dg,b_RSHIFT_2_->_d,ks_AND_ku_->_kv,b_RSHIFT_3_->_e,d_OR_j_->_k,NOT_p_->_q,NOT_cr_->_cs,du_OR_dt_->_dv,kf_LSHIFT_15_->_kj,NOT_ac_->_ad,fo_RSHIFT_5_->_fr,hz_OR_ik_->_il,jx_AND_jz_->_ka,gh_OR_gi_->_gj,kk_RSHIFT_1_->_ld,hz_RSHIFT_5_->_ic,as_RSHIFT_2_->_at,NOT_jy_->_jz,1_AND_am_->_an,ci_OR_ct_->_cu,hg_AND_hh_->_hj,jq_OR_jw_->_jx,v_OR_w_->_x,la_LSHIFT_15_->_le,dh_AND_dj_->_dk,dp_AND_dr_->_ds,jq_AND_jw_->_jy,au_OR_av_->_aw,NOT_bf_->_bg,z_OR_aa_->_ab,ga_AND_gc_->_gd,hz_AND_ik_->_im,jt_AND_jv_->_jw,z_AND_aa_->_ac,jr_OR_js_->_jt,hb_LSHIFT_1_->_hv,hf_OR_hl_->_hm,ib_OR_ic_->_id,fq_OR_fr_->_fs,cq_AND_cs_->_ct,ia_OR_ig_->_ih,dd_OR_do_->_dp,d_AND_j_->_l,ib_AND_ic_->_ie,as_RSHIFT_3_->_au,be_AND_bg_->_bh,dd_AND_do_->_dq,NOT_l_->_m,1_AND_gd_->_ge,y_AND_ae_->_ag,fo_AND_fz_->_gb,NOT_ie_->_if,e_AND_f_->_h,x_RSHIFT_3_->_z,y_OR_ae_->_af,hf_AND_hl_->_hn,NOT_h_->_i,NOT_hn_->_ho,he_RSHIFT_5_->_hh";
            string [] inputs = input.Split(',');
            Dictionary<string, bool> instructions = new Dictionary<string, bool>();

            inputs.ToList().ForEach(o => instructions.Add(o, false));
            int instructionCount = instructions.Count;
            int pass = 0;

            while (instructionCount > 0)
            {
                foreach (string i in inputs)
                {
                    if (!instructions [i])
                    {
                        if (ProcessInstruction(i))
                        {
                            instructions [i] = true;
                            instructionCount--;
                        }
                    }
                }
                pass++;
                Console.WriteLine("Instructions left to process: " + instructionCount);
                Console.WriteLine("Number of passes: " + pass);
            }
            if (wireSignals.ContainsKey("a"))
            {
                Console.WriteLine("Value of a is: " + wireSignals ["a"]);
            }
            Console.Read();
        }

        static bool ProcessInstruction(string instruction)
        {
            string [] parts = instruction.Split('_');
            if (parts [parts.Length - 1] == "a")
            {
                unprocessed.Add(instruction);
            }
            bool parsed = false;
            if (instruction.Contains("NOT"))
            {
                if (wireSignals.ContainsKey(parts [1]) || CheckIfInt(parts [1]))
                {
                    wireSignals.Remove(parts [3]);
                    wireSignals.Add(parts [3], Process(parts [1], string.Empty, "NOT"));
                    parsed = true;
                }

            }
            else if (instruction.Contains("AND"))
            {
                if (IsProcessable(parts [0], parts [2]))
                {
                    wireSignals.Remove(parts [4]);
                    wireSignals.Add(parts [4], Process(parts [0], parts [2], "AND"));
                    parsed = true;
                }
                else if (CheckIfInt(parts [0]) && wireSignals.ContainsKey(parts [2]))
                {

                }
            }
            else if (instruction.Contains("OR"))
            {
                if (IsProcessable(parts [0], parts [2]))
                {
                    wireSignals.Remove(parts [4]);
                    wireSignals.Add(parts [4], Process(parts [0], parts [2], "OR"));
                    parsed = true;
                }
            }
            else if (instruction.Contains("LSHIFT"))
            {
                if (IsProcessable(parts [0], parts [2]))
                {
                    wireSignals.Remove(parts [4]);
                    wireSignals.Add(parts [4], Process(parts [0], parts [2], "LSHIFT"));
                    parsed = true;
                }
            }
            else if (instruction.Contains("RSHIFT"))
            {
                if (IsProcessable(parts [0], parts [2]))
                {
                    wireSignals.Remove(parts [4]);
                    wireSignals.Add(parts [4], Process(parts [0], parts [2], "RSHIFT"));
                    parsed = true;
                }
            }
            else
            {
                if (!wireSignals.ContainsKey(parts [2]))
                {
                    if (!CheckIfInt(parts [0]))
                    {
                        if (wireSignals.ContainsKey(parts [0]))
                        {
                            wireSignals.Add(parts [2], (ushort)wireSignals [parts [0]]);
                            parsed = true;
                        }
                    }
                    else
                    {
                        wireSignals.Add(parts [2], ushort.Parse(parts [0]));
                        parsed = true;
                    }
                }
                else
                {
                    if (!CheckIfInt(parts [0]))
                    {
                        if (wireSignals.ContainsKey(parts [0]))
                        {
                            wireSignals [parts [2]] = (ushort)wireSignals [parts [0]];
                            parsed = true;
                        }
                    }
                    else
                    {
                        wireSignals [parts [2]] = ushort.Parse(parts [0]);
                        parsed = true;
                    }
                }
            }
            return parsed;
        }

        static bool CheckIfInt(string a)
        {
            ushort result = 0;
            if (ushort.TryParse(a, out result))
            {
                return true;
            }
            return false;
        }
        static bool IsProcessable(string a, string b)
        {
            if (wireSignals.ContainsKey(a) && wireSignals.ContainsKey(b))
            {
                return true;
            }
            if (CheckIfInt(a) && wireSignals.ContainsKey(b))
            {
                return true;
            }
            if (wireSignals.ContainsKey(a) && CheckIfInt(b))
            {
                return true;
            }
            if (CheckIfInt(a) && CheckIfInt(b))
            {
                return true;
            }
            return false;
        }
        static ushort Process(string a, string b, string operation)
        {
            ushort left = 0;
            ushort right = 0;
            ushort result = 0;
            left = ParseStringToUShort(a);
            right = ParseStringToUShort(b);

            switch (operation)
            {
                case "AND":
                    result = (ushort)(left & right);
                    break;
                case "OR":
                    result = (ushort)(left | right);
                    break;
                case "LSHIFT":
                    result = (ushort)(left << right);
                    break;
                case "RSHIFT":
                    result = (ushort)(left >> right);
                    break;
                case "NOT":
                    result = (ushort)~left;
                    break;
            }
            return result;
        }
        private static ushort ParseStringToUShort(string a)
        {
            ushort number = 0;
            if (CheckIfInt(a))
            {
                number = ushort.Parse(a);
            }
            else if (wireSignals.ContainsKey(a))
            {
                number = (ushort)wireSignals [a];
            }
            return number;
        }
    }
}